using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class HealthViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name= "Do you have any health issue(s)?")]
        public bool? HaveHealthIssues { get; set; }

        [Display(Name = "Health Issues")]
        public string? HealthIssues { get; set; }

        [Required]
        [Display(Name = "Any major or minor current or past physical impediment e.g surgery.")]
        public string? PhysicalImpediments { get; set; }
    }
}
