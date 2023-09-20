using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfileEducationalProfessionalDto : SimpleProfileDto
    {
        public EducationLevelsEnum? Education { get; set; }
        public string? Occupation { get; set; }
    }
}
