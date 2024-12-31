using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularF1APIv2.Models
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public int DriverNumber { get; set; }
        public string DriverName { get; set; }
        public int DriverPoints { get; set; }
        public int DriverPosition { get; set; }
        public string DriverDetails { get; set; }
        public string Driver_Image { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }

        public string TeamName { get; set; }
    }
}
