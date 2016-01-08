using System.ComponentModel.DataAnnotations;

namespace SimpleConsumer.Model
{
    public class KinderGardenSettings
    {
        [Display(Name = "Open From")]
        public int OpenFromHours { get; set; }

        [Display(Name = "Open To")]
        public int OpenToHours { get; set; }

        [Display(Name = "Address")]
        public string StreetAddress { get; set; }

        [Display(Name = "Phone Number")]
        public string MainPhoneNumber { get; set; }
    }
}
