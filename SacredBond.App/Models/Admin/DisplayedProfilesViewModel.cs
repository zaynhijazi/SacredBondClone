using SacredBond.Common.Enums;

namespace SacredBond.App.Models.Admin
{
    public class DisplayedProfilesViewModel
    {
        
        public ProfileStatus ReportType { get; set; }
        public List<AdminProfileViewModel> AdminProfiles { get; set; } = new List<AdminProfileViewModel>();
    }
}
