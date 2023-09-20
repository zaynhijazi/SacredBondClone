using SacredBond.App.Models.Admin;
using SacredBond.Common.Enums;

namespace SacredBond.App.Models.Home
{
    public class HomeViewModel
    {
        public ProfileStatus? ProfileStatus { get; set; }
        public DateTime? ProfileStatusDate { get; set; }
        public int? ProfileId { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public bool IsPending { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public int CompletedPercentage { get; set; }

        public MatchDetails Matches { get; set; } = new MatchDetails();
        public MatchDetails InterestedIn { get; set; } = new MatchDetails();
    }

    public class MatchDetails
    {
        public List<MatchViewModel> Current { get; set; } = new List<MatchViewModel>();
        public List<MatchViewModel> Historical { get; set; } = new List<MatchViewModel>();
    }


}
