using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacredBond.App.Models.Profile
{
    public class MaritalViewModel : BaseProfileViewModel
    {
        [Required]
        [Display(Name = "Marital Status")]
        public MaritalStatuses? MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Do you have children?")]
        public bool? HasChildren { get; set; }

        [Required]
        [Display(Name = "Number Of Children")]
        public int? NumberOfChildren { get; set; }
    }
}
