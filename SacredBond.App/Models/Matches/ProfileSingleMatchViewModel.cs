using SacredBond.App.Models.Admin;
using SacredBond.Common.Enums;

namespace SacredBond.App.Models.Matches
{
    public class ProfileSingleMatchViewModel: AdminProfileViewModel
    {
        public InterestedInStatus IntrestedInStatus { get; set; }
        
        public int SpouseId { get; set; }

    }
}
