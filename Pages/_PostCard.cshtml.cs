using MicroBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MicroBlog.Pages
{
    public class _PostCardModel : PageModel
    {
        public List<Models.Post> Posts { get; set; } = new List<Models.Post>();

        public void OnGet()
        {
            
        }
    }
}
