using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Common.Enums
{
    public enum InterestedInStatus
    {
        Pending,
        Approved,
        Rejected,
        [Display(Name ="In Review")]
        InReview,
        Completed,
        Canceled
    }
}
