using MicroBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace MicroBlog.Pages
{
    public class DetailsModel : PageModel
    {
        //Receive id root parameter from the URL
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        //Fetch article by Id
        public Post Post { get; set; } = new Post();

        public void OnGet()
        {
            if (System.IO.File.Exists("data/posts.json"))
            {
                Post = System.Text.Json.JsonSerializer.Deserialize<List<Post>>(System.IO.File.ReadAllText("data/posts.json"))?.FirstOrDefault(p => p.Id == Id);
            }
            else
            {
                //Show message if no posts found
                ViewData["Message"] = "No posts found.";
            }
        }
    }
}
