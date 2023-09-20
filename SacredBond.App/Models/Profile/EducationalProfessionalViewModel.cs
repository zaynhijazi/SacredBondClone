using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacredBond.App.Models.Profile
{
    public class EducationalProfessionalViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Education")]
        public EducationLevelsEnum? Education { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string? Occupation { get; set; }
    }
}
