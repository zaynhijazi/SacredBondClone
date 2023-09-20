using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Common.Enums
{
    public enum AllSomeNot
    {
        [Display(Name = "All The Time")]
        [Description("All The Time")]
        AllTheTime,
        Sometimes,
        [Display(Name = "Not At All")]
        [Description("Not At All")]
        NotAtAll
    }
}
