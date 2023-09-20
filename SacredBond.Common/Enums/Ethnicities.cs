using System.ComponentModel;

namespace SacredBond.Common.Enums
{
    public enum Ethnicities
    {
        Asian,
        Arab,
        [Description("African/African American")]
        Black,
        [Description("Hispanic/Latino")]
        Hispanic,
        [Description("White/Caucasian")]
        White,
        Other = 999
    }
}
