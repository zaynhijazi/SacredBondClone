using SacredBond.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SacredBond.Common.DTOs
{
    public class MatchDto
    {
        public int MatchId { get; set; }
        public int ProfileId { get; set; }
        public Guid ProfileUId { get; set; }
        public Guid SpouseUId { get; set; }
        public string? ProfileUserFirstName { get; set; } = string.Empty;
        public string? ProfileUserLastName { get; set; } = string.Empty;
        public Genders? ProfileUserGender { get; set; }
        public string? ProfileUserEmail { get; set; }
        public string? ProfileUserPhone { get; set; }
        public int SpouseId { get; set; }
        public string? SpouseUserFirstName { get; set; } = string.Empty;
        public string? SpouseUserLastName { get; set; } = string.Empty;
        public Genders? SpouseUserGender { get; set; }
        public string? SpouseUserEmail { get; set; }
        public string? SpouseUserPhone { get; set; }
        public InterestedInStatus? Status { get; set; }
        public DateTime? StatusChangedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public DateTime? ReviewedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
