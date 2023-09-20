using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.Common.Enums
{
    public enum SpouseMaritalStatuses
    {
        [Display(Name ="Never Married")]
        [Description("Never Married")]
        NeverMarried,
        Divorced,
        Widowed,
        [Display(Name = "I have no preference")]
        [Description("I have no preference")]
        NoPreference

    }
}
