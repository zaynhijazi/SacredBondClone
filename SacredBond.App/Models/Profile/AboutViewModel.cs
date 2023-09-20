using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class AboutViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Active/Energic")]
        public AllSomeNot? ActiveEnergetic { get; set; }

        [Required] 
        public AllSomeNot? Adaptable { get; set; }

        [Required] 
        public AllSomeNot? Sensitive { get; set; }

        [Required] 
        public AllSomeNot? Flexible { get; set; }

        [Required]
        [Display(Name = "Laid Back")]
        public AllSomeNot? LaidBack { get; set; }

        [Required] 
        public AllSomeNot? Patient { get; set; }

        [Required] 
        public AllSomeNot? Practical { get; set; }

        [Required] 
        public AllSomeNot? Private { get; set; }

        [Required] 
        public AllSomeNot? Shy { get; set; }

        [Required] 
        public AllSomeNot? Social { get; set; }
        [Display(Name = "Share About Your self")]

        [Required] 
        public string? ShareAboutYourself { get; set; }

        [Required]
        [Display(Name = "Describe Typical Day")]
        public string? DescribeTypicalDay { get; set; }

        [Required]
        [Display(Name = "Short Term Goals")]
        public string? ShortTermGoals { get; set; }

        [Required]
        [Display(Name = "Long Term Goals")]
        public string? LongTermGoals { get; set; }

        [Required]
        [Display(Name = "Hobbies And Activities")]
        public string? HobbiesAndActivities { get; set; }
    }
}
