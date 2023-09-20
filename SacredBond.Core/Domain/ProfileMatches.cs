using SacredBond.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Domain
{
    public class ProfileMatches
    
    {
        public int MatchId { get; set; }
        public virtual ICollection<ProfileMatchStatusChange> ProfileMatchStatusChanges{ get; set; }

        public int ProfileId { get; set; }
        public int SpouseId { get; set; }
        public InterestedInStatus Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime UpdateTime { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public DateTime? InReviewDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CanceledDate { get; set; }
    }
}
