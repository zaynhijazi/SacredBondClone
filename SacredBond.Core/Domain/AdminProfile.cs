using SacredBond.Common.Enums;

namespace SacredBond.Core.Domain
{
    public class AdminProfile
    {
        public ProfileStatus Status { get; set; }

        #region user information
        public Guid UserId { get; set; }
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        public Genders? Gender { get; set; }
        public string? GenderName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public int ProfileId { get; set; }
        #endregion

        #region Spouses
        public AllSomeNot? WantSpouseActiveEnergetic { get; set; }
        public AllSomeNot? WantSpouseAdaptable { get; set; }
        public AllSomeNot? WantSpouseSensitive { get; set; }
        public AllSomeNot? WantSpouseFlexible { get; set; }
        public AllSomeNot? WantSpouseLaidBack { get; set; }
        public AllSomeNot? WantSpousePatient { get; set; }
        public AllSomeNot? WantSpousePractical { get; set; }
        public AllSomeNot? WantSpousePrivate { get; set; }
        public AllSomeNot? WantSpouseShy { get; set; }
        public AllSomeNot? WantSpouseSocial { get; set; }
        public SpouseMaritalStatuses? SpouseMaritalStatusesId { get; set; }
        public int? MinimumSpouseAge { get; set; }
        public int? MaximumSpouseAge { get; set; }
        public YesNoMaybeOptions? ConsiderSpouseWithChildren { get; set; }
        public string? LookingForInSpouse { get; set; } = string.Empty;
        public WaliOptions? DoYouHaveAWali { get; set; }
        public string? WaliName { get; set; }= string.Empty;
        public string? WaliRelationship { get; set; }= string.Empty;
        public string? WaliPhone { get; set; }= string.Empty;
        public string? WaliEmail { get; set; } = string.Empty;
        #endregion

        #region Contact
        public ContactMethods? BestWayToContact { get; set; }
        public bool? ShareInfoWithMatches { get; set; }
        public YesNoMaybeOptions? HasDomesticViolenceHistory { get; set; }
        #endregion

        #region Educational & Professional Background 
        public EducationLevelsEnum? Education { get; set; }
        public string? Occupation { get; set; } = string.Empty;
        #endregion

        #region Family
        public string? LiveWithFamilyPostMarriage { get; set; } = string.Empty;
        #endregion

        #region Finance
        public FinancesHandlingAfterMarriageOptions? FinancesHandlingAfterMarriage { get; set; }
        public bool? WifeContributeFinancially { get; set; }
        public bool? HusbandSoleProvider { get; set; }
        public YesNoMaybeOptions? WantToWorkAfterMarriage { get; set; }
        public YesNoMaybeOptions? WantWifeToWorkAfterMarriage { get; set; }
        public bool? HasDebts { get; set; }
        #endregion

        #region Health
        public string? HealthIssues { get; set; } = string.Empty;
        public string? PhysicalImpediments { get; set; }= string.Empty;
        public bool? HaveHealthIssues { get; set; }
        #endregion

        #region Marital and Family Background
        public MaritalStatuses? MaritalStatus { get; set; }
        public bool? HasChildren { get; set; }
        public int? NumberOfChildren { get; set; }
        #endregion

        #region Personal Information 
        public DateTime? DateOfBirth { get; set; }
        public string? AddressLine1 { get; set; }= string.Empty;
        public string? AddressLine2 { get; set; }= string.Empty;
        public string? City { get; set; }= string.Empty;
        public States? State { get; set; }
        public string? ZipCode { get; set; } = string.Empty;
        public LegalStatuses? LegalStatus { get; set; }
        public Ethnicities? Ethnicity { get; set; }
        public string? Languages { get; set; } = string.Empty;
        public LanguagesEnum? PreferredLanguage { get; set; }
        #endregion

        #region Religion
        public string? ReligionImportance { get; set; } = string.Empty;
        public bool? DoYouPray5Times { get; set; }
        public WearsHijabOptions? WearsHijab { get; set; }
        public bool? HasBeard { get; set; }
        #endregion

        #region About Yourself
        public AllSomeNot? ActiveEnergetic { get; set; }
        public AllSomeNot? Adaptable { get; set; }
        public AllSomeNot? Sensitive { get; set; }
        public AllSomeNot? Flexible { get; set; }
        public AllSomeNot? LaidBack { get; set; }
        public AllSomeNot? Patient { get; set; }
        public AllSomeNot? Practical { get; set; }
        public AllSomeNot? Private { get; set; }
        public AllSomeNot? Shy { get; set; }
        public AllSomeNot? Social { get; set; }
        public string? ShareAboutYourself { get; set; } = string.Empty;
        public string? DescribeTypicalDay { get; set; }= string.Empty;
        public string? ShortTermGoals { get; set; }= string.Empty;
        public string? LongTermGoals { get; set; }= string.Empty;
        public string? HobbiesAndActivities { get; set; }= string.Empty;
        #endregion

        public DateTime CreateTime { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime StatusChangedDate { get; set; }
    }
}
