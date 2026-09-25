using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Post> Posts { get; set; } = new List<Models.Post>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Load posts from the JSON file
            if (System.IO.File.Exists("data/posts.json"))
            {
                var posts = System.Text.Json.JsonSerializer.Deserialize<List<Models.Post>>(System.IO.File.ReadAllText("data/posts.json")) ?? new List<Models.Post>();
                foreach (var post in posts)
                {
                    if (post.Body.Length > 300)
                    {
                        post.Body = post.Body.Substring(0, 300) + "...";
                    }
                }
                Posts = posts;
            }
        }
    }
}
