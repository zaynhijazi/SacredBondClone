namespace SacredBond.Common.DTOs
{
    public class ProfileDto : SimpleProfileDto
    {
        public ProfilePersonalDto Personal { get; set; }
        public ProfileEducationalProfessionalDto EducationalProfessional { get; set; }
        public ProfileMaritalDto Marital { get; set; }
        public ProfileReligionDto Religion { get; set; }
        public ProfileAboutDto About { get; set; }
        public ProfileSpouseDto Spouse { get; set; }
        public ProfileHealthDto Health { get; set; }
        public ProfileFamilyDto Family { get; set; }
        public ProfileFinanceDto Finance { get; set; }
        public ProfileContactDto Contact { get; set; }
    }
}
