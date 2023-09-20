using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class FamilyViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Would you live with your parents or any other family members post marriage (e.g.siblings, grandparents)")]
        public string? LiveWithFamilyPostMarriage { get; set; }

    }
}
