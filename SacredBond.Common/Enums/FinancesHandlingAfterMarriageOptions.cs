using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.Common.Enums
{
    public enum FinancesHandlingAfterMarriageOptions
    {
        [Display(Name ="Joint Account(s)")]
        [Description("Joint Account(s)")]
        JointAccounts,
        [Display(Name = "Separate Account(s)")]
        [Description("Separate Account(s)")]
        SeparateAccounts,
        [Display(Name = "Other")]
        [Description("Other")]
        Other
    }
}
