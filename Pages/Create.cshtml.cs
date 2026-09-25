using MicroBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Post Post { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Show contact contact page again
                return Page();
            }
            else
            {
                //Set post ID as an auto-incrementing value based on the number of posts in the database
                List<Post> posts = System.Text.Json.JsonSerializer.Deserialize<List<Post>>(System.IO.File.ReadAllText("data/posts.json")) ?? new List<Post>();
                Post.Id = posts.Count > 0 ? posts.Max(p => p.Id) + 1 : 1;

                //Set the CreatedUtc property to the current UTC time
                Post.CreatedUtc = DateTime.UtcNow;

                // Save post to database
                posts.Add(Post);
                var json = System.Text.Json.JsonSerializer.Serialize(posts);
                System.IO.File.WriteAllText("data/posts.json", json);

                //Redirect to the index page after the post is created
                return RedirectToPage("/Index");
            }

            //PLAN
            //create the page to create a new post
            //save the posts on a .json file
            //pull the posts from the .json file and display them on the index page
            //click on a post on the index page and then redirect to the details page where all the details of the post are displayed

        }
    }
}
