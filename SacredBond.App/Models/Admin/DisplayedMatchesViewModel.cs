using SacredBond.Common.Enums;

namespace SacredBond.App.Models.Admin
{
    public class DisplayedMatchesViewModel
    {
        public InterestedInStatus ReportType { get; set; }
        public List<MatchViewModel> Matches { get; set; } = new List<MatchViewModel>();
    }
}
