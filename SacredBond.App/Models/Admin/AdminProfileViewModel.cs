using SacredBond.App.Models.Profile;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Admin
{
    public class AdminProfileViewModel
    {
        [Display(Name = "Primary Language(s) Spoken At Home")]
        public string? languages { get; set; } = string.Empty;
        public PersonalViewModel PersonalViewModel { get; set; } = new PersonalViewModel();
        public EducationalProfessionalViewModel EducationalProfessionalViewModel { get; set; }= new EducationalProfessionalViewModel();
        public MaritalViewModel MaritalViewModel { get; set; } = new MaritalViewModel();
        public ReligionViewModel ReligionViewModel { get; set; } = new ReligionViewModel();
        public AboutViewModel AboutViewModel { get; set; } = new AboutViewModel();
        public SpouseViewModel SpouseViewModel { get; set; } = new SpouseViewModel();
        public HealthViewModel HealthViewModel { get; set; } = new HealthViewModel();
        public FamilyViewModel FamilyViewModel { get; set; } = new FamilyViewModel();
        public FinanceViewModel FinanceViewModel { get; set; } = new FinanceViewModel();    
        public ContactViewModel ContactViewModel { get; set; } = new ContactViewModel();

        public List<MatchViewModel> HistoricalMatches = new List<MatchViewModel>();
    }


}
