using Microsoft.AspNetCore.Mvc;
using SacredBond.App.Mappers;
using SacredBond.App.Models.Profile;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using SacredBond.Core.ProfilePictureStorage;
using SacredBond.Core.Services;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace SacredBond.App.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileService _profileService;
        private readonly IAzureBlobStorageService _azureBlogStorageService;

        public ProfileController(ILogger<HomeController> logger,
            IPrincipal principal,
            IProfileService profileService, IAzureBlobStorageService azureBlogStorageService) : base(logger, principal)
        {
            _profileService = profileService;
            _azureBlogStorageService = azureBlogStorageService;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetSimpleProfile(id);

            if (dto.Status == ProfileStatus.Pending)
            {
                if (!dto.IsPersonalCompleted)
                    return RedirectToAction("Personal", new { id });
                if (!dto.IsPicturesCompleted)
                    return RedirectToAction("ProfilePictures", new { id });
                if (!dto.IsEducationalProfessionalCompleted)
                    return RedirectToAction("EducationalProfessional", new { id });
                if (!dto.IsMaritalCompleted)
                    return RedirectToAction("Marital", new { id });
                if (!dto.IsReligionCompleted)
                    return RedirectToAction("Religion", new { id });
                if (!dto.IsAboutCompleted)
                    return RedirectToAction("About", new { id });
                if (!dto.IsSpouseCompleted)
                    return RedirectToAction("Spouse", new { id });
                if (!dto.IsHealthCompleted)
                    return RedirectToAction("Health", new { id });
                if (!dto.IsFamilyCompleted)
                    return RedirectToAction("Family", new { id });
                if (!dto.IsFinanceCompleted)
                    return RedirectToAction("Finance", new { id });
                if (!dto.IsContactCompleted)
                    return RedirectToAction("Contact", new { id });
            }
            return RedirectToAction("Summary", new { id });
        }

        public async Task<IActionResult> Personal(int id)
        {
            if (!CanViewProfile(id))
                return RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfilePersonal(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Personal(PersonalViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfilePersonal(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfilePersonal(dto);
            }
            return RedirectToAction("EducationalProfessional", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> ProfilePictures(int id)
        {
            if (!CanViewProfile(id))
                return RedirectToAction("Index", "Home");

            var dto = await _azureBlogStorageService.GetProfilePictures(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);
            var viewModel = ProfileMapper.Map(dto);
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ProfilePictures(ProfilePicturesViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _azureBlogStorageService.GetProfilePictures(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }
                if (!viewModel.IsPicturesCompleted)
                {
                    foreach (PictureViewModel picturesViewModel in viewModel.pictures)
                    {
                        if (String.Equals(picturesViewModel.SasToken, "NoValue"))
                        {
                            picturesViewModel.SasToken = null;
                        }
                        if (String.Equals(picturesViewModel.PictureUri, "NoValue"))
                        {
                            picturesViewModel.PictureUri = null;
                        }
                        BlobResponseDto result = await _azureBlogStorageService.UploadAsync(picturesViewModel.Image, viewModel.ProfileId, User.Id, picturesViewModel.PictureNumber);
                        if (result.Error)
                        {
                            var originalDTO = await _azureBlogStorageService.GetProfilePictures(viewModel.ProfileId);
                            ProfileMapper.Map(viewModel, originalDTO);
                            return View(viewModel);
                        }
                        picturesViewModel.PictureUri = result.Blob.Uri;
                        picturesViewModel.SasToken = result.SasToken;
                    }
                }
                else
                {
                    bool check = viewModel.pictures[0].Image == null && viewModel.pictures[1].Image == null && viewModel.pictures[2].Image == null;
                    if (!check)
                    {
                        foreach (PictureViewModel picturesViewModel in viewModel.pictures)
                        {
                            if (picturesViewModel.Image != null)
                            {
                                BlobResponseDto result = await _azureBlogStorageService.ReplaceBlobByUriAsync(picturesViewModel.PictureUri, picturesViewModel.Image);
                                if (result.Error)
                                {
                                    var originalDTO = await _azureBlogStorageService.GetProfilePictures(viewModel.ProfileId);
                                    ProfileMapper.Map(viewModel, originalDTO);
                                    return View(viewModel);
                                }
                                picturesViewModel.PictureUri = result.Blob.Uri;
                                picturesViewModel.SasToken = result.SasToken;
                            }
                        }
                    }
                }
                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfilePictures(dto);
            }
            return RedirectToAction("EducationalProfessional", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> EducationalProfessional(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileEducationalProfessional(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EducationalProfessional(EducationalProfessionalViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileEducationalProfessional(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileEducationalProfessional(dto);
            }

            return RedirectToAction("Marital", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Marital(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileMarital(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Marital(MaritalViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileMarital(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileMarital(dto);
            }

            return RedirectToAction("Religion", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Religion(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileReligion(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Religion(ReligionViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileReligion(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }
                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileReligion(dto);
            }

            return RedirectToAction("About", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> About(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileAbout(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> About(AboutViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileAbout(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileAbout(dto);
            }

            return RedirectToAction("Spouse", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Spouse(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileSpouse(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Spouse(SpouseViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileSpouse(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileSpouse(dto);
            }

            return RedirectToAction("Health", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Health(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileHealth(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Health(HealthViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileHealth(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileHealth(dto);
            }

            return RedirectToAction("Family", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Family(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileFamily(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Family(FamilyViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileFamily(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileFamily(dto);
            }

            return RedirectToAction("Finance", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Finance(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileFinance(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Finance(FinanceViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileFinance(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileFinance(dto);
            }

            return RedirectToAction("Contact", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Contact(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetProfileContact(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            if (CanEditProfile(viewModel.ProfileId, await _profileService.GetProfileStatus(viewModel.ProfileId)))
            {
                if (!ModelState.IsValid)
                {
                    var originalDTO = await _profileService.GetProfileContact(viewModel.ProfileId);
                    ProfileMapper.Map(viewModel, originalDTO);
                    return View(viewModel);
                }

                var dto = ProfileMapper.Map(viewModel);
                await _profileService.SaveProfileContact(dto);
            }

            return RedirectToAction("Summary", new { id = viewModel.ProfileId });
        }

        public async Task<IActionResult> Summary(int id)
        {
            if (!CanViewProfile(id))
                RedirectToAction("Index", "Home");

            var dto = await _profileService.GetSimpleProfile(id);
            dto.CanEditProfile = CanEditProfile(id, dto.Status);

            var viewModel = ProfileMapper.Map(dto);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Summary(SummaryViewModel viewModel)
        {
            if (!CanViewProfile(viewModel.ProfileId))
                return RedirectToAction("Index", "Home");

            var dto = await _profileService.GetSimpleProfile(viewModel.ProfileId);

            if (!ModelState.IsValid)
            {
                viewModel = ProfileMapper.Map(dto);
                return View(viewModel);
            }

            if (dto.Status == ProfileStatus.Pending || dto.Status == ProfileStatus.Rejected)
            {
                await _profileService.SubmitProfile(viewModel.ProfileId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                await _profileService.EditProfile(viewModel.ProfileId);
                return RedirectToAction("Summary", new { id = viewModel.ProfileId });
            }
        }

        private bool CanViewProfile(int id)
        {
            return User.IsAdmin || User.ProfileId == id;
        }

        private bool CanEditProfile(int id, ProfileStatus status)
        {
            return CanViewProfile(id) &&
                   (status == ProfileStatus.Pending ||
                    status == ProfileStatus.Rejected ||
                   (User.IsAdmin && status != ProfileStatus.Approved));
        }
    }
}
