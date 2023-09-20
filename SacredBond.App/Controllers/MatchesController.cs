using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Mappers;
using SacredBond.Core.Repositories;
using SacredBond.Core.Services;
using System.Security.Principal;

namespace SacredBond.App.Controllers
{
    public class MatchesController : BaseController
    {
        private readonly IProfileService profileService;
        private readonly IProfileMatchesService profileMatchesService;

        public MatchesController(ILogger<HomeController> logger,
            IPrincipal principal,
            IProfileService profileService,
            IProfileMatchesService profileMatchesService) : base(logger, principal)
        {
            this.profileService = profileService;
            this.profileMatchesService = profileMatchesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SingleMatch(int spouseId)
        {
            var profileId = User.ProfileId;
            var spouseProfile = profileService.GetProfile(spouseId);

            var profileMatch = profileMatchesService.GetProfileMatch(profileId, spouseId);

            var viewModel = AdminMapper.Map(spouseProfile, profileMatch);

            return View(viewModel);
        }

    }
}
