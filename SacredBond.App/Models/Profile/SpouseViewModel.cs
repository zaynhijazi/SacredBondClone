using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class SpouseViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Want Spouse Active Energetic")]
        public AllSomeNot? WantSpouseActiveEnergetic { get; set; }

        [Required]
        [Display(Name = "Want Spouse Adaptable")]
        public AllSomeNot? WantSpouseAdaptable { get; set; }

        [Required]
        [Display(Name = "Want Spouse Sensitive")]
        public AllSomeNot? WantSpouseSensitive { get; set; }

        [Required]
        [Display(Name = "Want Spouse Flexible")]
        public AllSomeNot? WantSpouseFlexible { get; set; }

        [Required]
        [Display(Name = "Want Spouse Laid Back")]
        public AllSomeNot? WantSpouseLaidBack { get; set; }

        [Required]
        [Display(Name = "Want Spouse Patient")]
        public AllSomeNot? WantSpousePatient { get; set; }

        [Required]
        [Display(Name = "Want Spouse Practical")]
        public AllSomeNot? WantSpousePractical { get; set; }

        [Required]
        [Display(Name = "Want Spouse Private")]
        public AllSomeNot? WantSpousePrivate { get; set; }

        [Required]
        [Display(Name = "Want Spouse Shy")]
        public AllSomeNot? WantSpouseShy { get; set; }

        [Required]
        [Display(Name = "Want Spouse Social")]
        public AllSomeNot? WantSpouseSocial { get; set; }

        [Required]
        [Display(Name = "Minimum Spouse Age")]
        public int? MinimumSpouseAge { get; set; }

        [Required]
        [Display(Name = "Maximum Spouse Age")]
        public int? MaximumSpouseAge { get; set; }

        [Required]
        [Display(Name = "Spouse Marital Status")]
        public SpouseMaritalStatuses? SpouseMaritalStatuses { get; set; }

        [Required]
        [Display(Name = "Would you consider someone with children?")]
        public YesNoMaybeOptions? ConsiderSpouseWithChildren { get; set; }

        [Required]
        [Display(Name = "What are you looking for in your spouse?")]
        public string? LookingForInSpouse { get; set; }
        
        [Display(Name = "Do you have a Wali?")]
        public WaliOptions? DoYouHaveAWali { get; set; }
        
        [Display(Name = "Wali Name")]
        public string? WaliName { get; set; }
        
        [Display(Name = "Wali Relationship")]
        public string? WaliRelationship { get; set; }
        
        [Display(Name = "Wali Phone")]
        public string? WaliPhone { get; set; }
        
        [Display(Name = "Wali Email")]
        public string? WaliEmail { get; set; }

        public Genders Gender { get; set; }
    }
}
