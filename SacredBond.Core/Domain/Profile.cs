using System.Runtime.InteropServices;
using SacredBond.Common.Enums;

namespace SacredBond.Core.Domain
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public virtual ICollection<ProfileStatusChange>? ProfileStatusChanges { get; set; }
        public virtual ICollection<ProfileLanguage>? ProfileLanguages { get; set; }

        public Guid ProfileUId { get; set; } = Guid.NewGuid();
        public ProfileStatus Status { get; set; }
        public DateTime StatusChangedDate { get; set; }
        public DateTime CreateTime { get; set; }
        public string UpdateBy { get; set; } = string.Empty;
        public DateTime UpdateTime { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public DateTime? RejectedDate { get; set; }
        public string? RejectReason { get; set; }=string.Empty;

        public bool IsPersonalCompleted { get; set; }
        public bool IsPicturesCompleted { get; set; }
        public bool IsEducationalProfessionalCompleted { get; set; }
        public bool IsMaritalCompleted { get; set; }
        public bool IsReligionCompleted { get; set; }
        public bool IsAboutCompleted { get; set; }
        public bool IsSpouseCompleted { get; set; }
        public bool IsHealthCompleted { get; set; }
        public bool IsFamilyCompleted { get; set; }
        public bool IsFinanceCompleted { get; set; }
        public bool IsContactCompleted { get; set; }

        #region Personal Information 
        public DateTime? DateOfBirth { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public States? State { get; set; }
        public string? ZipCode { get; set; }
        public LegalStatuses? LegalStatus { get; set; }
        public Ethnicities? Ethnicity { get; set; }
        public LanguagesEnum? PreferredLanguage { get; set; }
        #endregion

        #region ProfilePictures
        public virtual IEnumerable<ProfilePicture> ProfilePictures { get; set; }
        #endregion



        #region Educational & Professional Background 
        public EducationLevelsEnum? Education { get; set; }
        public string? Occupation { get; set; }
        #endregion

        #region Marital and Family Background
        public MaritalStatuses? MaritalStatus { get; set; }
        public bool? HasChildren { get; set; }
        public int? NumberOfChildren { get; set; }
        #endregion

        #region Religion
        public string? ReligionImportance { get; set; }
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
        public string? ShareAboutYourself { get; set; }
        public string? DescribeTypicalDay { get; set; }
        public string? ShortTermGoals { get; set; }
        public string? LongTermGoals { get; set; }
        public string? HobbiesAndActivities { get; set; }
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

        public int? MinimumSpouseAge { get; set; }
        public int? MaximumSpouseAge { get; set; }

        public SpouseMaritalStatuses? SpouseMaritalStatusesId { get; set; }
        public YesNoMaybeOptions? ConsiderSpouseWithChildren { get; set; }
        public string? LookingForInSpouse { get; set; }
        public WaliOptions? DoYouHaveAWali { get; set; }
        public string? WaliName { get; set; }
        public string? WaliRelationship { get; set; }
        public string? WaliPhone { get; set; }
        public string? WaliEmail { get; set; }
        #endregion

        #region Health
        public bool? HaveHealthIssues { get; set; }
        public string? HealthIssues { get; set; }
        public string? PhysicalImpediments { get; set; }
        #endregion

        #region Family
        public string? LiveWithFamilyPostMarriage { get; set; }
        #endregion

        #region Finance
        public FinancesHandlingAfterMarriageOptions? FinancesHandlingAfterMarriage { get; set; }
        public bool? WifeContributeFinancially { get; set; }
        public bool? HusbandSoleProvider { get; set; }
        public YesNoMaybeOptions? WantToWorkAfterMarriage { get; set; }
        public YesNoMaybeOptions? WantWifeToWorkAfterMarriage { get; set; }
        public bool? HasDebts { get; set; }
        #endregion

        #region Contact
        public ContactMethods? BestWayToContact { get; set; }
        public bool? ShareInfoWithMatches { get; set; }
        public YesNoMaybeOptions? HasDomesticViolenceHistory { get; set; }
        #endregion
    }
}