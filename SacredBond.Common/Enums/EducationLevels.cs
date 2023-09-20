using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.Common.Enums
{
    public enum EducationLevelsEnum
    {
        [Description("Some High School")]
        [Display(Name = "Some High School")]
        SomeHighSchool = 1,
        [Description("High School")]
        [Display(Name ="High School")]
        HighSchool,
        [Description("Bachelors Degree")]
        [Display(Name ="Bachelors Degree")]
        BachelorsDegree,
        [Description("Masters Degree")]
        [Display(Name ="Masters Degree")]
        MastersDegree,
        [Description("PhD Or Higher")]
        [Display(Name = "PhD Or Higher")]
        PhDOrHigher,
        Other
    }
}
