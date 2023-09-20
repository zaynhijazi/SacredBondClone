using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.ProfileSearch
{
    public class SearchViewModel
    {
        public int PageNumber { get; set; } = 1;
       
        #region personal
        
        [Display(Name = "State")]
        public States? State { get; set; }

        [Display(Name = "Legal Status In Country of Residence")]
        public LegalStatuses? LegalStatus { get; set; }

        [Display(Name = "Ethnicity?")]
        public Ethnicities? Ethnicity { get; set; }

        [Display(Name = "Language")]
        public LanguagesEnum? PreferredLanguage { get; set; }
        #endregion

        #region Education
        [Display(Name = "Education")]
        public EducationLevelsEnum? Education { get; set; }
        
        #endregion

        #region Marital
        [Display(Name = "Marital Status")]
        public MaritalStatuses? MaritalStatus { get; set; }
        [Display(Name = "Have children?")]
        public bool? HasChildren { get; set; }
        #endregion

        #region Religion
        [Display(Name = "Pray 5 times?")]
        public bool? DoYouPray5Times { get; set; }
        [Display(Name = "Wear Hijab?")]
        public WearsHijabOptions? WearsHijab { get; set; }
        [Display(Name = "Have a beard?")]
        public bool? HasBeard { get; set; }
        #endregion

        #region Spouse
        [Display(Name = "Want Spouse Active Energetic")]
        public AllSomeNot? WantSpouseActiveEnergetic { get; set; }
        [Display(Name = "Want Spouse Adaptable")]
        public AllSomeNot? WantSpouseAdaptable { get; set; }
        [Display(Name = "Want Spouse Sensitive")]
        public AllSomeNot? WantSpouseSensitive { get; set; }
        [Display(Name = "Want Spouse Flexible")]
        public AllSomeNot? WantSpouseFlexible { get; set; }
        [Display(Name = "Want Spouse Laid Back")]
        public AllSomeNot? WantSpouseLaidBack { get; set; }
        [Display(Name = "Want Spouse Patient")]
        public AllSomeNot? WantSpousePatient { get; set; }
        [Display(Name = "Want Spouse Practical")]
        public AllSomeNot? WantSpousePractical { get; set; }
        [Display(Name = "Want Spouse Private")]
        public AllSomeNot? WantSpousePrivate { get; set; }
        [Display(Name = "Want Spouse Shy")]
        public AllSomeNot? WantSpouseShy { get; set; }
        [Display(Name = "Want Spouse Social")]
        public AllSomeNot? WantSpouseSocial { get; set; }

        [Display(Name = "Minimum Spouse Age")]
        public int? MinimumSpouseAge { get; set; }
        [Display(Name = "Maximum Spouse Age")]
        public int? MaximumSpouseAge { get; set; }
        #endregion

        #region Finance
        [Display(Name = "Finance handling after marriage")]
        public FinancesHandlingAfterMarriageOptions? FinancesHandlingAfterMarriage { get; set; }
        [Display(Name = "Wife contribute financially?")]
        public bool? WifeContributeFinancially { get; set; }
        [Display(Name = "Husband sole provider?")]
        public bool? HusbandSoleProvider { get; set; }
        [Display(Name = "Do you want to work after marriage?")]
        public YesNoMaybeOptions? WantToWorkAfterMarriage { get; set; }
        [Display(Name = "Do you want your wife to work after marriage?")]
        public YesNoMaybeOptions? WantWifeToWorkAfterMarriage { get; set; }
        [Display(Name = "Have any debts?")]
        public bool? HasDebts { get; set; }
        #endregion

        #region Health
        [Display(Name = "Have health issue(s)?")]
        public bool? HaveHealthIssues { get; set; }
        #endregion

        #region About
        [Display(Name = "Active/Energic")]
        public AllSomeNot? ActiveEnergetic { get; set; }
        public AllSomeNot? Adaptable { get; set; }
        public AllSomeNot? Sensitive { get; set; }
        public AllSomeNot? Flexible { get; set; }
        [Display(Name = "Laid Back")]
        public AllSomeNot? LaidBack { get; set; }
        public AllSomeNot? Patient { get; set; }
        public AllSomeNot? Practical { get; set; }
        public AllSomeNot? Private { get; set; }
        public AllSomeNot? Shy { get; set; }
        public AllSomeNot? Social { get; set; }
        #endregion
    }
}
