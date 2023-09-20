using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.Profile
{
    public class FinanceViewModel : BaseProfileViewModel
    {
        
        [Required]
        [Display(Name = "How do you see finances being handled after marriage?")]
        public FinancesHandlingAfterMarriageOptions? FinancesHandlingAfterMarriage { get; set; }
        
        [Display(Name = "Do you believe your wife should contribute financially?")]
        public bool? WifeContributeFinancially { get; set; }
        
        [Display(Name = "Do you believe your husband should be the sole provider?")]
        public bool? HusbandSoleProvider { get; set; }
        
        [Display(Name = "Do you want to work after marriage?")]
        public YesNoMaybeOptions? WantToWorkAfterMarriage { get; set; }
        
        [Display(Name = "Do you want your wife to work after marriage?")]
        public YesNoMaybeOptions? WantWifeToWorkAfterMarriage { get; set; }

        [Required]
        [Display(Name = "Do you have any debts?")]
        public bool? HasDebts { get; set; }
        public Genders Gender { get; set; }
    }
}
