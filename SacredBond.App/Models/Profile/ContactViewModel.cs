using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class ContactViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Best way to contact you")]
        public ContactMethods? BestWayToContact { get; set; }

        [Required]
        [Display(Name = "Do you give permission to share the above info with potential matches?")]
        public bool? ShareInfoWithMatches { get; set; }

        [Required]
        [Display(Name = "Have you ever been involved in any domestic violence whether reported or not?")]
        public YesNoMaybeOptions? HasDomesticViolenceHistory { get; set; }
    }
}
