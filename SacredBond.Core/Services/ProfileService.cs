using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using SacredBond.Core.Mappers;
using SacredBond.Core.Repositories;
using System.Security.Principal;

namespace SacredBond.Core.Services
{
    public class ProfileService : BaseService, IProfileService
    {
        private readonly IProfileRepository Profiles;
        private readonly ILanguageRepository Languages;
        private readonly IProfileLanguageRepository ProfileLanguages;
        private readonly IAdminProfileRepository AdminProfiles;
        private readonly IProfileStatusChangeRepository ProfileStatusChangeRepository;
        private readonly IProfilePicturesRepository ProfilePictures;
        private readonly UserManager<User> UserManager;
        public ProfileService(ILogger<ProfileService> logger, IPrincipal principal,
            IProfileRepository profiles,
            ILanguageRepository languages,
            IProfileLanguageRepository profileLanguages,
            IAdminProfileRepository adminProfiles,
            IProfileStatusChangeRepository profileStatusChangeRepository,
            IProfilePicturesRepository profilePicturesRepository,
            UserManager<User> userManager)
            : base(logger, principal)
        {
            Profiles = profiles;
            Languages = languages;
            UserManager = userManager;
            ProfileLanguages = profileLanguages;
            AdminProfiles = adminProfiles;
            ProfileStatusChangeRepository = profileStatusChangeRepository;
            ProfilePictures = profilePicturesRepository;
        }

        public async Task<SimpleProfileDto> GetSimpleProfile(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapSimpleProfile(profile);
        }
        public async Task<ProfileDto> GetFullProfile(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");
            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == id);
            if (user == null)
                throw new Exception("Unable to find user by profile id");

            return ProfileMapper.MapFullProfile(user, profile);
        }
        public async Task<ProfilePersonalDto> GetProfilePersonal(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");
            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == id);
            if (user == null)
                throw new Exception("Unable to find user by profile id");

            //var languages = ProfileLanguages.GetAsQueryable(pl => pl.ProfileId == id).ToList();
            //profile.ProfileLanguages = languages.Select(lang => new Language { Id = lang.LanguageId }).ToList();

            return ProfileMapper.MapPersonal(user, profile);
        }
        public async Task<ProfileEducationalProfessionalDto> GetProfileEducationalProfessional(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapEducationalProfessional(profile);
        }
        public async Task<ProfileMaritalDto> GetProfileMarital(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapMarital(profile);
        }
        public async Task<ProfileReligionDto> GetProfileReligion(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
            {
                throw new Exception("Unable to find profile");
            }
            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == id);

            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }

            return ProfileMapper.MapReligion(user, profile);
        }
        public async Task<ProfileAboutDto> GetProfileAbout(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapAbout(profile);
        }
        public async Task<ProfileSpouseDto> GetProfileSpouse(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
            {
                throw new Exception("Unable to find profile");
            }

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == id);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }
            return ProfileMapper.MapSpouse(user, profile);
        }
        public async Task<ProfileHealthDto> GetProfileHealth(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapHealth(profile);
        }
        public async Task<ProfileFamilyDto> GetProfileFamily(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapFamily(profile);
        }
        public async Task<ProfileFinanceDto> GetProfileFinance(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == id);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }
            return ProfileMapper.MapFinance(user, profile);
        }
        public async Task<ProfileContactDto> GetProfileContact(int id)
        {
            var profile = await Profiles.GetAsync(id);
            if (profile == null)
                throw new Exception("Unable to find profile");

            return ProfileMapper.MapContact(profile);
        }
        public async Task<ProfilePersonalDto> SaveProfilePersonal(ProfilePersonalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");
            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == dto.ProfileId);
            if (user == null)
                throw new Exception("Unable to find user by profile id");

            ProfileLanguages.DeleteMany(pl => pl.ProfileId == profile.ProfileId);
            foreach (var lang in dto.PrimaryLanguages)
            {
                ProfileLanguages.Add(new ProfileLanguage { ProfileId = profile.ProfileId, LanguageId = (int)lang });
            }

            profile = ProfileMapper.Map(profile, dto);
            profile.IsPersonalCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapPersonal(user, profile);
        }
        public async Task<ProfilePicturesDto> SaveProfilePictures(ProfilePicturesDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");
            

            //profile = ProfileMapper.Map(profile, dto);
            if (!profile.IsPicturesCompleted)
            {
                profile.IsPicturesCompleted = true;
                foreach (PictureDto pictureDto in dto.pictures)
                {
                    ProfilePicture pic = new ProfilePicture();

                    pic.PictureUri = pictureDto.PictureUri;
                    pic.SasToken = pictureDto.SasToken;
                    pic.PictureNumber = pictureDto.PictureNumber;
                    pic.ProfileId = pictureDto.ProfileId;
                    ProfilePictures.Add(pic);

                }
            }
            else
            {
                foreach (ProfilePicture pic in profile.ProfilePictures)
                {
                    foreach (PictureDto pictureDto in dto.pictures)
                    {
                        if (pic.PictureNumber == pictureDto.PictureNumber && !String.Equals(pic.SasToken, pictureDto.SasToken))
                        {
                            pic.SasToken = pictureDto.SasToken;
                        }
                    }
                }
            }
            await ProfilePictures.SaveChangesAsync();
            await Profiles.SaveChangesAsync();
             
            return ProfileMapper.MapPictures(profile);
        }


        public async Task<ProfileEducationalProfessionalDto> SaveProfileEducationalProfessional(ProfileEducationalProfessionalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsEducationalProfessionalCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapEducationalProfessional(profile);
        }
        public async Task<ProfileMaritalDto> SaveProfileMarital(ProfileMaritalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsMaritalCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapMarital(profile);
        }
        public async Task<ProfileReligionDto> SaveProfileReligion(ProfileReligionDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
            {
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");
            }

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == dto.ProfileId);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }

            profile = ProfileMapper.Map(profile, dto);
            profile.IsReligionCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapReligion(user, profile);
        }
        public async Task<ProfileAboutDto> SaveProfileAbout(ProfileAboutDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsAboutCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapAbout(profile);
        }
        public async Task<ProfileSpouseDto> SaveProfileSpouse(ProfileSpouseDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == dto.ProfileId);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }
            profile = ProfileMapper.Map(profile, dto);
            profile.IsSpouseCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapSpouse(user, profile);
        }
        public async Task<ProfileHealthDto> SaveProfileHealth(ProfileHealthDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsHealthCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapHealth(profile);
        }
        public async Task<ProfileFamilyDto> SaveProfileFamily(ProfileFamilyDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsFamilyCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapFamily(profile);
        }
        public async Task<ProfileFinanceDto> SaveProfileFinance(ProfileFinanceDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == dto.ProfileId);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }

            profile = ProfileMapper.Map(profile, dto);
            profile.IsFinanceCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapFinance(user, profile);
        }
        public async Task<ProfileContactDto> SaveProfileContact(ProfileContactDto dto)
        {

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var profile = await Profiles.GetAsync(dto.ProfileId);
            if (profile == null)
                throw new Exception($"Unable to find Profile with Id {dto.ProfileId}");

            profile = ProfileMapper.Map(profile, dto);
            profile.IsContactCompleted = true;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapContact(profile);
        }

        public async Task<ProfileDto> SubmitProfile(int profileId)
        {
            var profile = await Profiles.GetAsync(profileId);
            if (profile == null)
            {
                throw new Exception($"Unable to find Profile with Id {profileId}");
            }

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == profileId);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }
            profile.SubmittedDate = DateTime.UtcNow;
            profile.Status = ProfileStatus.Submitted;
            profile.StatusChangedDate = DateTime.UtcNow;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapFullProfile(user, profile);
        }
        public async Task<ProfileDto> EditProfile(int profileId)
        {
            var profile = await Profiles.GetAsync(profileId);
            if (profile == null)
            {
                throw new Exception($"Unable to find Profile with Id {profileId}");
            }

            var user = UserManager.Users.FirstOrDefault(u => u.ProfileId == profileId);
            if (user == null)
            {
                throw new Exception("Unable to find user by profile id");
            }
            profile.Status = ProfileStatus.Pending;
            profile.StatusChangedDate = DateTime.UtcNow;
            profile.UpdateBy = User.Email;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();

            return ProfileMapper.MapFullProfile(user, profile);
        }

        public int? GetProfilesCountByStatus(ProfileStatus status)
        {
            var profiles = AdminProfiles.GetAsQueryable(p => p.Status == status);

            if (status == ProfileStatus.Pending)
            {
                profiles = profiles.Where(p => p.Email != "sacredbonddev@gmail.com");
            }

            return profiles?.Count();
        }
        public IQueryable<AdminProfile> GetProfilesByStatus(ProfileStatus status)
        {
            return AdminProfiles.GetAsQueryable(x => x.Status == status);
        }

        public IQueryable<AdminProfile> GetAll()
        {
            return AdminProfiles.GetAll();
        }
        public List<CountDetailsDto> GetProfilesCounts()
        {
            var profiles = AdminProfiles.GetAll();

            var profileStatusList = Enum.GetNames(typeof(ProfileStatus));
            List<CountDetailsDto> applicationCounts = new List<CountDetailsDto>();

            var applicationsData = profiles.GroupBy(_ => _.Status).Select(g => new
            {
                Name = g.Key,
                Count = g.Count()
            }).
            OrderByDescending(gp => gp.Count).ToList();

            foreach (var item in profileStatusList)
            {
                applicationCounts.Add(new CountDetailsDto
                {
                    Name = item,
                    Count = applicationsData.Where(d => d.Name.ToString() == item).Select(d => d.Count).FirstOrDefault()
                });
            }

            return applicationCounts;
        }
        public AdminProfile? GetProfile(int profileId)
        {
            return AdminProfiles.Get(profileId);
        }
        public async Task UpdateProfileStatus(int profileId, string userEmail, ProfileStatus status, string? rejectReason)
        {
            var profile = await Profiles.GetAsync(profileId);
            if (profile == null)
            {
                throw new Exception($"Unable to find Profile with Id {profileId}");
            }

            if (status == ProfileStatus.Approved)
            {
                profile.ApprovedDate = DateTime.UtcNow;
            }
            else if (status == ProfileStatus.Rejected)
            {
                profile.RejectedDate = DateTime.UtcNow;
                profile.RejectReason = rejectReason;
            }

            profile.Status = status;
            profile.StatusChangedDate = DateTime.UtcNow;
            profile.UpdateBy = userEmail;
            profile.UpdateTime = DateTime.UtcNow;

            await Profiles.SaveChangesAsync();


            ProfileStatusChange profileStatusChange = new ProfileStatusChange();
            profileStatusChange.FromStatus = ProfileStatus.Submitted;
            profileStatusChange.ToStatus = status;
            profileStatusChange.CreatedBy = userEmail;
            profileStatusChange.CreateTime = DateTime.UtcNow;
            profileStatusChange.ProfileId = profileId;

            await ProfileStatusChangeRepository.AddAsync(profileStatusChange);
        }

        public async Task<ProfileStatus> GetProfileStatus(int profileId)
        {
            var profile = await Profiles.GetAsync(profileId);
            if (profile == null)
                throw new Exception($"Unable to find profile {profileId}.");

            return profile.Status;
        }
    }

    public interface IProfileService
    {
        Task<SimpleProfileDto> GetSimpleProfile(int id);
        Task<ProfileDto> GetFullProfile(int id);

        Task<ProfilePersonalDto> GetProfilePersonal(int id);
        Task<ProfileEducationalProfessionalDto> GetProfileEducationalProfessional(int id);
        Task<ProfileMaritalDto> GetProfileMarital(int id);
        Task<ProfileReligionDto> GetProfileReligion(int id);
        Task<ProfileAboutDto> GetProfileAbout(int id);
        Task<ProfileSpouseDto> GetProfileSpouse(int id);
        Task<ProfileHealthDto> GetProfileHealth(int id);
        Task<ProfileFamilyDto> GetProfileFamily(int id);
        Task<ProfileFinanceDto> GetProfileFinance(int id);
        Task<ProfileContactDto> GetProfileContact(int id);

        Task<ProfilePersonalDto> SaveProfilePersonal(ProfilePersonalDto dto);
        Task<ProfilePicturesDto> SaveProfilePictures(ProfilePicturesDto dto);
        Task<ProfileEducationalProfessionalDto> SaveProfileEducationalProfessional(ProfileEducationalProfessionalDto dto);
        Task<ProfileMaritalDto> SaveProfileMarital(ProfileMaritalDto dto);
        Task<ProfileReligionDto> SaveProfileReligion(ProfileReligionDto dto);
        Task<ProfileAboutDto> SaveProfileAbout(ProfileAboutDto dto);
        Task<ProfileSpouseDto> SaveProfileSpouse(ProfileSpouseDto dto);
        Task<ProfileHealthDto> SaveProfileHealth(ProfileHealthDto dto);
        Task<ProfileFamilyDto> SaveProfileFamily(ProfileFamilyDto dto);
        Task<ProfileFinanceDto> SaveProfileFinance(ProfileFinanceDto dto);
        Task<ProfileContactDto> SaveProfileContact(ProfileContactDto dto);
        Task<ProfileDto> SubmitProfile(int profileId);
        int? GetProfilesCountByStatus(ProfileStatus status);
        IQueryable<AdminProfile> GetProfilesByStatus(ProfileStatus status);
        List<CountDetailsDto> GetProfilesCounts();
        AdminProfile? GetProfile(int profileId);
        Task UpdateProfileStatus(int profileId, string userEmail, ProfileStatus status, string? rejectReason);
        IQueryable<AdminProfile> GetAll();
        Task<ProfileDto> EditProfile(int profileId);
        Task<ProfileStatus> GetProfileStatus(int profileId);
    }
}
