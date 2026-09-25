using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MicroBlog.Models
{
    public class Post
    {
        public int Id { get; set; }

        [JsonPropertyName("title")]
        [Required] public string title { get; set; }
        [Required] public string Body { get; set; }
        [Required] public string Author { get; set; }
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;

    }
}
