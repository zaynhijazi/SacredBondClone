using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class ReligionViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Importance of Religion in your life")]
        public string? ReligionImportance { get; set; }

        [Required]
        [Display(Name = "Do you pray 5 times a day?")]
        public bool? DoYouPray5Times { get; set; }

        [Display(Name = "Do you Wear Hijab")]
        public WearsHijabOptions? WearsHijab { get; set; }
        
        [Display(Name = "Do you have a beard?")]
        public bool? HasBeard { get; set; }
        
        public Genders Gender { get; set; }
    }
}
