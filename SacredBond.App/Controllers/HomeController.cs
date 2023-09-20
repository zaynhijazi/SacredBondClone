using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Mappers;
using SacredBond.App.Models;
using SacredBond.App.Models.Admin;
using SacredBond.Common.Enums;
using SacredBond.Core.Services;
using System.Diagnostics;
using System.Security.Principal;

namespace SacredBond.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly IProfileMatchesService _profileMatchesService;

        public HomeController(ILogger<HomeController> logger,
            IPrincipal principal,
            IProfileService profileService,
            IProfileMatchesService profileMatchesService) : base(logger, principal)
        {
            _profileService = profileService;
            _profileMatchesService = profileMatchesService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Role == Roles.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }

            var profile = await _profileService.GetSimpleProfile(User.ProfileId);
            var viewModel = HomeMapper.Map(profile);

            var matches = _profileMatchesService.GetProfileMatches(User.ProfileId);
            viewModel.Matches = HomeMapper.MapMatches(matches);

            var interests = _profileMatchesService.GetMatchesBySpouseId(User.ProfileId);
            viewModel.InterestedIn = HomeMapper.MapMatches(interests, true);

            return View(viewModel);
        }

        private JsonResult HandleMatchesDT(List<MatchViewModel> matches, DataTablesRequest dataTablesRequest)
        {
            var recordsTotal = matches.Count();

            var searchText = dataTablesRequest.Search.Value?.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                matches = matches.Where(s =>
                    s.DisplayedProfileIdentifier.ToLower().Contains(searchText) ||
                    Enum.GetName<InterestedInStatus>(s.Status).ToLower().Contains(searchText) ||
                    s.StatusChangedDate.ToString().ToLower().Contains(searchText)
                ).ToList();
            }

            var recordsFiltered = matches.Count();

            var sortColumnName = dataTablesRequest.Columns.ElementAt(dataTablesRequest.Order.ElementAt(0).Column + 1).Name;
            var sortDirection = dataTablesRequest.Order.ElementAt(0).Dir.ToLower();

            //matches = matches.OrderBy(sortColumnName, sortDirection == "asc");

            var skip = dataTablesRequest.Start;
            var take = dataTablesRequest.Length;
            var data = matches
                .Skip(skip)
                .Take(take)
                .ToList();

            return new JsonResult(new
            {
                Draw = dataTablesRequest.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = data,
            });
        }

        public JsonResult GetMoreInterestedIn(DataTablesRequest dataTablesRequest)
        {
            var interests = _profileMatchesService.GetMatchesBySpouseId(User.ProfileId);
            var interestDetails = HomeMapper.MapMatches(interests, true);

            return HandleMatchesDT(interestDetails.Current, dataTablesRequest);
        }

       
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Terms()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}