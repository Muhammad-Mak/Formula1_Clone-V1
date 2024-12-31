using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularF1APIv2.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Fullname { get; set; }
        
        public string FavoriteTeam { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        //0 will be normal user 1 will be admin
        public ICollection<Post> Posts { get; set; }
    }
}
