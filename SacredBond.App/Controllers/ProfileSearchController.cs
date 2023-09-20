using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Helpers;
using SacredBond.App.Mappers;
using SacredBond.App.Models.ProfileSearch;
using SacredBond.Core.Domain;
using SacredBond.Core.Services;
using System.Security.Principal;
using X.PagedList;


namespace SacredBond.App.Controllers
{
    public class ProfileSearchController : BaseController
    {
        private readonly IProfileService _profileService;
        public ProfileSearchController(ILogger<HomeController> logger,
                    IPrincipal principal,
                    IProfileService profileService) : base(logger, principal)
        {
            _profileService = profileService;
        }

        public IActionResult Index()
        {
            return View(new SearchViewModel());
        }


        private IQueryable<AdminProfile> FilterProfiles(IQueryable<AdminProfile> profiles, SearchViewModel searchModel)
        {
            var recordsTotal = profiles.Count();

            if (searchModel.State.HasValue)
            {
                profiles = profiles.Where(p => p.State.HasValue && p.State.Value == searchModel.State);
            }

            if (searchModel.LegalStatus.HasValue)
            {
                profiles = profiles.Where(p => p.LegalStatus.HasValue && p.LegalStatus.Value == searchModel.LegalStatus.Value);
            }

            if (searchModel.Ethnicity.HasValue)
            {
                profiles = profiles.Where(p => p.Ethnicity.HasValue && p.Ethnicity.Value == searchModel.Ethnicity.Value);
            }

            if (searchModel.PreferredLanguage.HasValue)
            {
                profiles = profiles.Where(p =>
                (p.PreferredLanguage.HasValue && p.PreferredLanguage.Value == searchModel.PreferredLanguage.Value)
                ||
                p.Languages.Contains(searchModel.PreferredLanguage.Value.ToString()));
            }

            if (searchModel.Education.HasValue)
            {
                profiles = profiles.Where(p => p.Education.HasValue && p.Education.Value == searchModel.Education.Value);
            }

            if (searchModel.MaritalStatus.HasValue)
            {
                profiles = profiles.Where(p => p.MaritalStatus.HasValue && p.MaritalStatus.Value == searchModel.MaritalStatus.Value);
            }

            if (searchModel.HasChildren.HasValue)
            {
                profiles = profiles.Where(p => p.HasChildren.HasValue && p.HasChildren.Value == searchModel.HasChildren.Value);
            }

            if (searchModel.DoYouPray5Times.HasValue)
            {
                profiles = profiles.Where(p => p.DoYouPray5Times.HasValue && p.DoYouPray5Times.Value == searchModel.DoYouPray5Times.Value);
            }

            if (searchModel.WearsHijab.HasValue)
            {
                profiles = profiles.Where(p => p.WearsHijab.HasValue && p.WearsHijab.Value == searchModel.WearsHijab.Value);
            }

            if (searchModel.HasBeard.HasValue)
            {
                profiles = profiles.Where(p => p.HasBeard.HasValue && p.HasBeard.Value == searchModel.HasBeard.Value);
            }

            if (searchModel.ActiveEnergetic.HasValue)
            {
                profiles = profiles.Where(p => p.ActiveEnergetic.HasValue && p.ActiveEnergetic.Value == searchModel.ActiveEnergetic.Value);
            }
            if (searchModel.Adaptable.HasValue)
            {
                profiles = profiles.Where(p => p.Adaptable.HasValue && p.Adaptable.Value == searchModel.Adaptable.Value);
            }
            if (searchModel.Sensitive.HasValue)
            {
                profiles = profiles.Where(p => p.Sensitive.HasValue && p.Sensitive.Value == searchModel.Sensitive.Value);
            }
            if (searchModel.Flexible.HasValue)
            {
                profiles = profiles.Where(p => p.Flexible.HasValue && p.Flexible.Value == searchModel.Flexible.Value);
            }
            if (searchModel.LaidBack.HasValue)
            {
                profiles = profiles.Where(p => p.LaidBack.HasValue && p.LaidBack.Value == searchModel.LaidBack.Value);
            }
            if (searchModel.Patient.HasValue)
            {
                profiles = profiles.Where(p => p.Patient.HasValue && p.Patient.Value == searchModel.Patient.Value);
            }
            if (searchModel.Practical.HasValue)
            {
                profiles = profiles.Where(p => p.Practical.HasValue && p.Practical.Value == searchModel.Practical.Value);
            }
            if (searchModel.Private.HasValue)
            {
                profiles = profiles.Where(p => p.Private.HasValue && p.Private.Value == searchModel.Private.Value);
            }
            if (searchModel.Shy.HasValue)
            {
                profiles = profiles.Where(p => p.Shy.HasValue && p.Shy.Value == searchModel.Shy.Value);
            }
            if (searchModel.Social.HasValue)
            {
                profiles = profiles.Where(p => p.Social.HasValue && p.Social.Value == searchModel.Social.Value);
            }

            if (searchModel.WantSpouseActiveEnergetic.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseActiveEnergetic.HasValue && p.WantSpouseActiveEnergetic.Value == searchModel.WantSpouseActiveEnergetic.Value);
            }
            if (searchModel.WantSpouseAdaptable.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseAdaptable.HasValue && p.WantSpouseAdaptable.Value == searchModel.WantSpouseAdaptable.Value);
            }
            if (searchModel.WantSpouseSensitive.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseSensitive.HasValue && p.WantSpouseSensitive.Value == searchModel.WantSpouseSensitive.Value);
            }
            if (searchModel.WantSpouseFlexible.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseFlexible.HasValue && p.WantSpouseFlexible.Value == searchModel.WantSpouseFlexible.Value);
            }
            if (searchModel.WantSpouseLaidBack.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseLaidBack.HasValue && p.WantSpouseLaidBack.Value == searchModel.WantSpouseLaidBack.Value);
            }
            if (searchModel.WantSpousePatient.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpousePatient.HasValue && p.WantSpousePatient.Value == searchModel.WantSpousePatient.Value);
            }
            if (searchModel.WantSpousePractical.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpousePractical.HasValue && p.WantSpousePractical.Value == searchModel.WantSpousePractical.Value);
            }
            if (searchModel.WantSpousePrivate.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpousePrivate.HasValue && p.WantSpousePrivate.Value == searchModel.WantSpousePrivate.Value);
            }
            if (searchModel.WantSpouseShy.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseShy.HasValue && p.WantSpouseShy.Value == searchModel.WantSpouseShy.Value);
            }
            if (searchModel.WantSpouseSocial.HasValue)
            {
                profiles = profiles.Where(p => p.WantSpouseSocial.HasValue && p.WantSpouseSocial.Value == searchModel.WantSpouseSocial.Value);
            }

            if (searchModel.MinimumSpouseAge.HasValue && searchModel.MinimumSpouseAge.Value > 0)
            {
                profiles = profiles.Where(p => p.MinimumSpouseAge.HasValue && p.MinimumSpouseAge.Value == searchModel.MinimumSpouseAge.Value);
            }

            if (searchModel.MaximumSpouseAge.HasValue && searchModel.MaximumSpouseAge.Value > 0)
            {
                profiles = profiles.Where(p => p.MaximumSpouseAge.HasValue && p.MaximumSpouseAge.Value == searchModel.MaximumSpouseAge.Value);
            }

            if (searchModel.HaveHealthIssues.HasValue)
            {
                profiles = profiles.Where(p => p.HaveHealthIssues.HasValue && p.HaveHealthIssues.Value == searchModel.HaveHealthIssues.Value);
            }

            if (searchModel.FinancesHandlingAfterMarriage.HasValue)
            {
                profiles = profiles.Where(p => p.FinancesHandlingAfterMarriage.HasValue && p.FinancesHandlingAfterMarriage.Value == searchModel.FinancesHandlingAfterMarriage.Value);
            }
            if (searchModel.WifeContributeFinancially.HasValue)
            {
                profiles = profiles.Where(p => p.WifeContributeFinancially.HasValue && p.WifeContributeFinancially.Value == searchModel.WifeContributeFinancially.Value);
            }
            if (searchModel.HusbandSoleProvider.HasValue)
            {
                profiles = profiles.Where(p => p.HusbandSoleProvider.HasValue && p.HusbandSoleProvider.Value == searchModel.HusbandSoleProvider.Value);
            }
            if (searchModel.WantToWorkAfterMarriage.HasValue)
            {
                profiles = profiles.Where(p => p.WantToWorkAfterMarriage.HasValue && p.WantToWorkAfterMarriage.Value == searchModel.WantToWorkAfterMarriage.Value);
            }
            if (searchModel.WantWifeToWorkAfterMarriage.HasValue)
            {
                profiles = profiles.Where(p => p.WantWifeToWorkAfterMarriage.HasValue && p.WantWifeToWorkAfterMarriage.Value == searchModel.WantWifeToWorkAfterMarriage.Value);
            }
            if (searchModel.HasDebts.HasValue)
            {
                profiles = profiles.Where(p => p.HasDebts.HasValue && p.HasDebts.Value == searchModel.HasDebts.Value);
            }

            return profiles;
        }


        [HttpPost]
        public IActionResult Search(SearchViewModel searchModel)
        {
            var profiles = _profileService.GetAll()
                .Where(p => p.Status == Common.Enums.ProfileStatus.Approved);

            if (User.Gender == Common.Enums.Genders.Female)
            {
                profiles = profiles.Where(p => p.Gender == Common.Enums.Genders.Male);
            }
            else if (User.Gender == Common.Enums.Genders.Male)
            {
                profiles = profiles.Where(p => p.Gender == Common.Enums.Genders.Female);
            }

            var pageSize = 10;

            profiles = FilterProfiles(profiles, searchModel);


            profiles = profiles.Select(profile => new AdminProfile
            {
                DateOfBirth = profile.DateOfBirth,
                ShareAboutYourself = profile.ShareAboutYourself,
                City = profile.City,
                State = profile.State,
                ProfileId = profile.ProfileId,
            });

            var results = ProfileMapper.MapMini(profiles);

            var PagedResults = PaginatedList<ProfileResultViewModel>.Create(results, searchModel.PageNumber, pageSize);
            return PartialView("ProfileSearchResults", PagedResults);
        }

        public IActionResult MoreInfo(int profileId)
        {
            var profile = _profileService.GetProfile(profileId);
            var viewModel = AdminMapper.Map(profile);
            ViewBag.ShowPersonalData = false;

            return View(viewModel);
        }
    }
}
