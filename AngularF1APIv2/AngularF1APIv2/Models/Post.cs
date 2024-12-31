using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularF1APIv2.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string Username { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string PostDetails { get; set; }
    }

    public class PostDTO
    {
        public string Username { get; set; }
        public string PostDetails { get; set; }
    }
}
