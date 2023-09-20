using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Helpers;
using SacredBond.App.Mappers;
using SacredBond.App.Models.Admin;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using SacredBond.Core.Services;
using System.Security.Principal;

namespace SacredBond.App.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IProfileMatchesService _profileMatchesService;
        private readonly IProfileService _profileService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AdminController(ILogger<HomeController> logger,
            IPrincipal principal,
            IAdminService adminService,
            IProfileMatchesService profileMatchesService,
            IProfileService profileService,
            IHttpContextAccessor httpContextAccessor) : base(logger, principal)
        {
            _adminService = adminService;
            _profileMatchesService = profileMatchesService;
            _profileService = profileService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var applicatiosCounts = _profileService.GetProfilesCounts();
            var matchesCount = _profileMatchesService.GetMatchesCounts();

            var viewModel = new AdminViewModel
            {
                ProfileCounts = AdminMapper.MapCounts(applicatiosCounts),
                MatchesCounts = AdminMapper.MapCounts(matchesCount)
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult SubmittedProfiles()
        {
            var submittedProfiles = _profileService.GetProfilesByStatus(ProfileStatus.Submitted).ToList();

            var viewModel = new DisplayedProfilesViewModel();
            viewModel.ReportType = ProfileStatus.Submitted;
            viewModel.AdminProfiles = AdminMapper.Map(submittedProfiles);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult ApprovedProfiles()
        {
            var approvedProfiles = _profileService.GetProfilesByStatus(ProfileStatus.Approved).ToList();

            var viewModel = new DisplayedProfilesViewModel();
            viewModel.ReportType = ProfileStatus.Approved;
            viewModel.AdminProfiles = AdminMapper.Map(approvedProfiles);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult RejectedProfiles()
        {
            var rejectedProfiles = _profileService.GetProfilesByStatus(ProfileStatus.Rejected).ToList();

            var viewModel = new DisplayedProfilesViewModel();
            viewModel.ReportType = ProfileStatus.Rejected;
            viewModel.AdminProfiles = AdminMapper.Map(rejectedProfiles);

            return View(viewModel);
        }

        #region profiles
        [HttpGet]
        public IActionResult GetProfiles(string reportType)
        {
            var viewModel = new DisplayedProfilesViewModel();
            Enum.TryParse<ProfileStatus>(reportType, true, out ProfileStatus status);

            var profiles = _profileService.GetProfilesByStatus(status).ToList();
            viewModel.ReportType = status;

            viewModel.AdminProfiles = AdminMapper.Map(profiles);

            return View(viewModel);
        }

        private JsonResult HandleProfiles(IQueryable<AdminProfile> profiles, DataTablesRequest dataTablesRequest)
        {
            var recordsTotal = profiles.Count();

            var searchText = dataTablesRequest.Search.Value?.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                profiles = profiles.Where(s =>
                    s.FullName.ToLower().Contains(searchText) ||
                    s.PhoneNumber.ToLower().Contains(searchText) ||
                    s.GenderName.ToLower().Contains(searchText) ||
                    s.Email.ToLower().Contains(searchText)
                );
            }
            var recordsFiltered = profiles.Count();

            var sortColumnName = dataTablesRequest.Columns.ElementAt(dataTablesRequest.Order.ElementAt(0).Column).Name;
            var sortDirection = dataTablesRequest.Order.ElementAt(0).Dir.ToLower();

            profiles = profiles.OrderBy(sortColumnName, sortDirection == "asc");

            var skip = dataTablesRequest.Start;
            var take = dataTablesRequest.Length;
            var data = profiles
                .Skip(skip)
                .Take(take)
                .ToList();

            return new JsonResult(new
            {
                Draw = dataTablesRequest.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = AdminMapper.Map(data)
            });
        }

        [HttpPost]
        public JsonResult GetProfiles(DataTablesRequest dataTablesRequest, string reportType)
        {
            Enum.TryParse<ProfileStatus>(reportType, true, out ProfileStatus status);
            var profiles = _profileService.GetProfilesByStatus(status);

            return HandleProfiles(profiles, dataTablesRequest);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfileStatus(int profileId, string status, string recipientEmail, string? rejectReason)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentNullException(nameof(status));
            }

            Enum.TryParse<ProfileStatus>(status, true, out ProfileStatus profileStatus);

            await _profileService.UpdateProfileStatus(profileId, User.Email, profileStatus, rejectReason);

            if (profileStatus == ProfileStatus.Rejected)
            {
                await _adminService.SendMessage("Reject Application Notification", rejectReason, recipientEmail);
            }

            return RedirectToAction("Index", "Admin");
        }
        #endregion

        #region more information
        public IActionResult MoreInfo(int profileId, bool personal = true)
        {
            var profile = _profileService.GetProfile(profileId);
            var matches = _profileMatchesService.GetProfileMatchesDetails(profileId);

            var viewModel = AdminMapper.Map(profile);
            viewModel.HistoricalMatches = AdminMapper.Map(matches);

            ViewBag.ShowPersonalData = personal;

            return View(viewModel);
        }
        #endregion

        #region matches
        [HttpGet]
        public IActionResult GetMatches(string status)
        {
            var viewModel = new DisplayedMatchesViewModel();
            Enum.TryParse<InterestedInStatus>(status, true, out InterestedInStatus matchStatus);

            var matches = _profileMatchesService.GetMatchesFullData().Where(m => m.Status == matchStatus).ToList();
            viewModel.ReportType = matchStatus;

            viewModel.Matches = AdminMapper.Map(matches);

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult GetMatches(DataTablesRequest dataTablesRequest, string reportType)
        {
            Enum.TryParse<InterestedInStatus>(reportType, true, out InterestedInStatus status);
            var matches = _profileMatchesService.GetMatchesFullData().Where(m => m.Status == status);

            return HandleMatches(matches, dataTablesRequest);
        }

        private JsonResult HandleMatches(IQueryable<MatchDto> matches, DataTablesRequest dataTablesRequest)
        {
            var recordsTotal = matches.Count();

            var searchText = dataTablesRequest.Search.Value?.ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                matches = matches.Where(m =>
                    m.ProfileUserFirstName.ToLower().Contains(searchText) ||
                    m.ProfileUserLastName.ToLower().Contains(searchText) ||
                    m.ProfileUserEmail.ToLower().Contains(searchText) ||
                    m.ProfileUserPhone.ToString().ToLower().Contains(searchText) ||
                    m.SpouseUserFirstName.ToLower().Contains(searchText) ||
                    m.SpouseUserLastName.ToLower().Contains(searchText) ||
                    m.SpouseUserEmail.ToLower().Contains(searchText) ||
                    m.SpouseUserPhone.ToString().ToLower().Contains(searchText)
                //m.Email.ToLower().Contains(searchText)
                );
            }

            var recordsFiltered = matches.Count();

            //var sortColumnName = dataTablesRequest.Columns.ElementAt(dataTablesRequest.Order.ElementAt(0).Column).Name;
            //var sortDirection = dataTablesRequest.Order.ElementAt(0).Dir.ToLower();
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
                Data = AdminMapper.Map(data)
            });
        }

        public IActionResult MatchMoreInfo(int profileId, int spouseId, bool personal = true)
        {
            var currentUserId = User.ProfileId;

            MatchProfilesViewModel viewModel = new MatchProfilesViewModel();

            var profile = _profileService.GetProfile(profileId);
            viewModel.Profile = AdminMapper.Map(profile);

            var spouse = _profileService.GetProfile(spouseId);
            viewModel.Spouse = AdminMapper.Map(spouse);

            var match = _profileMatchesService.GetMatch(profileId, spouseId);
            viewModel.Status = match.Status;
            viewModel.ApprovedDate = match.ApprovedDate;
            viewModel.RejectedDate = match.RejectedDate;
            viewModel.StatusChangedDate = match.StatusChangedDate;

            ViewBag.CanBeCanceled = false;
            if ((profileId == User.ProfileId && match.Status == InterestedInStatus.Pending) ||
                (User.IsInRole(Roles.Admin.ToString()) && (match.Status == InterestedInStatus.Pending || match.Status == InterestedInStatus.InReview)))
            {
                ViewBag.CanBeCanceled = true;
            }

            ViewBag.ShowPersonalData = personal;

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMatchStatus(int? profileId, int spouseId, string status, string oldStatus,
            string recipientEmail, string spouseName)
        {
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentNullException(nameof(status));
            }

            if (profileId == null) // in case of user single match, user will not be the requester
                // so profile id will be the spouse id which is the requester, and spouse id will be logged in user id
            {
                profileId = spouseId;
                spouseId = User.ProfileId;
            }

            Enum.TryParse<InterestedInStatus>(status, true, out InterestedInStatus matchStatus);
            Enum.TryParse<InterestedInStatus>(oldStatus, true, out InterestedInStatus oldMatchStatus);

            await _profileMatchesService.UpdateMatchStatus(profileId.Value, spouseId, User.Email, matchStatus, oldMatchStatus);
            await _adminService.SendMessageForMatchStatus(matchStatus, recipientEmail, spouseName);

            return RedirectToAction("Index", "Admin");
        }


        #endregion
    }
}
