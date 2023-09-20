using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Admin
{
    public class MatchViewModel
    {
        public int MatchId { get; set; }
        public int ProfileId { get; set; }
        public Guid ProfileUId { get; set; }
        public string? DisplayedProfileIdentifier { get; set; }=string.Empty;

        [Display(Name ="User Full Name")]
        public string ProfileUserFullName { get; set; } = string.Empty;
        [Display(Name = "User Gender")]
        public Genders? ProfileUserGender { get; set; }

        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        public string? ProfileUserEmail { get; set; }

        [Display(Name = "User Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? ProfileUserPhone { get; set; }
        public int SpouseId { get; set; }
        [Display(Name = "Spouse Full Name")]
        public string SpouseUserFullName { get; set; } = string.Empty;
        [Display(Name = "Spouse Gender")]
        public Genders? SpouseUserGender { get; set; }

        [Display(Name = "Spouse Email")]
        [DataType(DataType.EmailAddress)]
        public string? SpouseUserEmail { get; set; }

        [Display(Name = "Spouse Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? SpouseUserPhone { get; set; }

        public InterestedInStatus Status { get; set; }
        [Display(Name = "Status Changed Date")]
        public DateTime StatusChangedDate { get; set; }
        [Display(Name = "Approved Date")]
        public DateTime? ApprovedDate { get; set; }
        [Display(Name = "Rejected Date")]
        public DateTime? RejectedDate { get; set; }
        [Display(Name = "Reviewed Date")]
        public DateTime? ReviewedDate { get; set; }
        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }
    }
}
