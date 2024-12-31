using System.ComponentModel.DataAnnotations;

namespace AngularF1APIv2.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public int TeamPoints { get; set; }
        public int TeamPosition { get; set; }
        public string TeamDetails { get; set; }
        public string Car_Image { get; set; }

        public string TeamDrivers { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}
