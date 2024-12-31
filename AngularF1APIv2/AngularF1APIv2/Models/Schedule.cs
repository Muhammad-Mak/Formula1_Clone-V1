using System.ComponentModel.DataAnnotations;

namespace AngularF1APIv2.Models
{
    public class Schedule
    {
        [Key]
        public int RaceID { get; set; }
        public string RaceDate { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Race_Image { get; set; }
    }
}
