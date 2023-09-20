using SacredBond.App.Helpers;
using SacredBond.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace SacredBond.App.Models.ProfileSearch
{
    public class ResultViewModel
    {
        public PaginatedList<ProfileResultViewModel>? PagedResults { get; set; }
    }

    public class ProfileResultViewModel
    {
        public int ProfileId { get; set; }
        public int Age { get; set; }
        
        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "State")]
        public States? State { get; set; }
        [Display(Name = "Share About Your self")]
        public string? ShareAboutYourself { get; set; }
    }
}
