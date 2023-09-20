using SacredBond.Common.Enums;

namespace SacredBond.Common.DTOs
{
    public class ProfilePersonalDto : SimpleProfileDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Genders Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public States? State { get; set; }
        public string? ZipCode { get; set; }
        public LegalStatuses? LegalStatus { get; set; }
        public Ethnicities? Ethnicity { get; set; }
        public List<LanguagesEnum> PrimaryLanguages { get; set; } = new List<LanguagesEnum>();
        public LanguagesEnum? PreferredLanguage { get; set; }
    }
}
