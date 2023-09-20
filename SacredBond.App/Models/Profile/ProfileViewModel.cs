namespace SacredBond.App.Models.Profile
{
    public class ProfileViewModel : BaseProfileViewModel
    {
        public PersonalViewModel Personal { get; set; }
        public EducationalProfessionalViewModel EducationalProfessional { get; set; }
        public MaritalViewModel Marital { get; set; }
        public ReligionViewModel Religion { get; set; }
        public AboutViewModel About { get; set; }
        public SpouseViewModel Spouse { get; set; }
        public HealthViewModel Health { get; set; }
        public FamilyViewModel Family { get; set; }
        public FinanceViewModel Finance { get; set; }
        public ContactViewModel Contact { get; set; }
    }
}
