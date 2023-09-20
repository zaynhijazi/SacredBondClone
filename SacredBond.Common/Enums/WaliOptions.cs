using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacredBond.Common.Enums
{
    public enum WaliOptions
    {

        [Display(Name = "I have a Wali")]
        [Description("I have a Wali")]
        IHaveAWali,
        [Display(Name = "Please appoint a Wali for me")]
        [Description("Please appoint a Wali for me")]
        PleaseAppointAWaliForMe
    }
}
