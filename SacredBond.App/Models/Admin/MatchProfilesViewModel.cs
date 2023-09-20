using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacredBond.App.Models.Admin
{
    public class MatchProfilesViewModel
    {
        public InterestedInStatus Status { get; set; }
        [Display(Name = "Status Changed Date")]
        public DateTime StatusChangedDate { get; set; }
        [Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }
        [Display(Name = "Rejected Date")]
        public DateTime? RejectedDate { get; set; }
        public AdminProfileViewModel Profile { get; set; } = new AdminProfileViewModel();
        public AdminProfileViewModel Spouse { get; set; } = new AdminProfileViewModel();

    }
}
