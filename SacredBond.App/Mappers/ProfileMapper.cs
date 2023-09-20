using SacredBond.App.Models.Profile;
using SacredBond.App.Models.ProfileSearch;
using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Common.Helpers;
using SacredBond.Core.Domain;

namespace SacredBond.App.Mappers
{
    internal static class ProfileMapper
    {
        internal static T MapSimpleProfile<T>(T viewModel, SimpleProfileDto dto) where T : BaseProfileViewModel
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));


            viewModel.ProfileId = dto.ProfileId;

            viewModel.IsAboutCompleted = dto.IsAboutCompleted;
            viewModel.IsContactCompleted = dto.IsContactCompleted;
            viewModel.IsEducationalProfessionalCompleted = dto.IsEducationalProfessionalCompleted;
            viewModel.IsFamilyCompleted = dto.IsFamilyCompleted;
            viewModel.IsFinanceCompleted = dto.IsFinanceCompleted;
            viewModel.IsHealthCompleted = dto.IsHealthCompleted;
            viewModel.IsMaritalCompleted = dto.IsMaritalCompleted;
            viewModel.IsPersonalCompleted = dto.IsPersonalCompleted;
            viewModel.IsPicturesCompleted = dto.IsPicturesCompleted;
            viewModel.IsReligionCompleted = dto.IsReligionCompleted;
            viewModel.IsSpouseCompleted = dto.IsSpouseCompleted;
            viewModel.IsPending = dto.Status == ProfileStatus.Pending;
            viewModel.IsSubmitted = dto.Status == ProfileStatus.Submitted;
            viewModel.IsApproved = dto.Status == ProfileStatus.Approved;
            viewModel.IsRejected = dto.Status == ProfileStatus.Rejected;
            viewModel.RejectReason = dto.RejectReason;
            viewModel.HasBeenApproved = dto.ApprovedDate.HasValue;
            viewModel.CanEditProfile = dto.CanEditProfile;

            return viewModel;
        }
        internal static SummaryViewModel Map(SimpleProfileDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();

            var viewModel = new SummaryViewModel()
            {
                ProfileId = dto.ProfileId,
                IsProfileCompleted = dto.IsAboutCompleted &
                             dto.IsMaritalCompleted &
                             dto.IsContactCompleted &
                             dto.IsEducationalProfessionalCompleted &
                             dto.IsFamilyCompleted &
                             dto.IsFinanceCompleted &
                             dto.IsHealthCompleted &
                             dto.IsPersonalCompleted &
                             dto.IsReligionCompleted &
                             dto.IsSpouseCompleted,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ProfileViewModel Map(ProfileDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();

            return new ProfileViewModel()
            {
                Personal = Map(dto.Personal),
                EducationalProfessional = Map(dto.EducationalProfessional),
                Marital = Map(dto.Marital),
                Religion = Map(dto.Religion),
                About = Map(dto.About),
                Spouse = Map(dto.Spouse),
                Health = Map(dto.Health),
                Family = Map(dto.Family),
                Finance = Map(dto.Finance),
                Contact = Map(dto.Contact)
            };
        }
        internal static PersonalViewModel Map(ProfilePersonalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();

            var viewModel = new PersonalViewModel()
            {
                ProfileId = dto.ProfileId,
                FullName = $"{dto.FirstName} {dto.LastName}",
                Email = dto.Email,
                Phone = dto.Phone,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                AddressLine1 = dto.AddressLine1,
                AddressLine2 = dto.AddressLine2,
                City = dto.City,
                State = dto.State,
                ZipCode = dto.ZipCode,
                LegalStatus = dto.LegalStatus,
                Ethnicity = dto.Ethnicity,
                PrimaryLanguages = dto.PrimaryLanguages,
                PreferredLanguage = dto.PreferredLanguage,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ProfilePicturesViewModel Map(ProfilePicturesDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            ProfilePicturesViewModel viewModel = new ProfilePicturesViewModel();
            viewModel.ProfileId = dto.ProfileId;
            foreach(PictureDto profileDto in dto.pictures)
            {
                var tempViewModel = new PictureViewModel()
                {
                    ProfilePictureId = profileDto.ProfilePictureId,
                    PictureUri = profileDto.PictureUri,
                    SasToken = profileDto.SasToken,
                    PictureNumber = profileDto.PictureNumber,
                    ProfileId = profileDto.ProfileId
                };
                if(tempViewModel.PictureUri == null)
                {
                    tempViewModel.PictureUri = string.Empty;
                }
                if (tempViewModel.SasToken == null)
                {
                    tempViewModel.SasToken = string.Empty;
                }

                viewModel.pictures.Add(tempViewModel);
            }
            
            return MapSimpleProfile(viewModel, dto);
        }
        internal static EducationalProfessionalViewModel Map(ProfileEducationalProfessionalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();

            var viewModel = new EducationalProfessionalViewModel()
            {
                ProfileId = dto.ProfileId,
                Occupation = dto.Occupation,
                Education = dto.Education,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static MaritalViewModel Map(ProfileMaritalDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new MaritalViewModel()
            {
                ProfileId = dto.ProfileId,
                MaritalStatus = dto.MaritalStatus,
                HasChildren = dto.HasChildren,
                NumberOfChildren = dto.NumberOfChildren,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ReligionViewModel Map(ProfileReligionDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();

            var viewModel = new ReligionViewModel()
            {
                ProfileId = dto.ProfileId,
                ReligionImportance = dto.ReligionImportance,
                DoYouPray5Times = dto.DoYouPray5Times,
                WearsHijab = dto.WearsHijab,
                HasBeard = dto.HasBeard,
                Gender = dto.Gender,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static AboutViewModel Map(ProfileAboutDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new AboutViewModel()
            {
                ProfileId = dto.ProfileId,
                ActiveEnergetic = dto.ActiveEnergetic,
                Adaptable = dto.Adaptable,
                Sensitive = dto.Sensitive,
                Flexible = dto.Flexible,
                LaidBack = dto.LaidBack,
                Patient = dto.Patient,
                Practical = dto.Practical,
                Private = dto.Private,
                Shy = dto.Shy,
                Social = dto.Social,
                ShareAboutYourself = dto.ShareAboutYourself,
                DescribeTypicalDay = dto.DescribeTypicalDay,
                ShortTermGoals = dto.ShortTermGoals,
                LongTermGoals = dto.LongTermGoals,
                HobbiesAndActivities = dto.HobbiesAndActivities
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static SpouseViewModel Map(ProfileSpouseDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new SpouseViewModel()
            {
                ProfileId = dto.ProfileId,
                WantSpouseActiveEnergetic = dto.WantSpouseActiveEnergetic,
                WantSpouseAdaptable = dto.WantSpouseAdaptable,
                WantSpouseFlexible = dto.WantSpouseFlexible,
                WantSpouseLaidBack = dto.WantSpouseLaidBack,
                WantSpousePatient = dto.WantSpousePatient,
                WantSpousePractical = dto.WantSpousePractical,
                WantSpousePrivate = dto.WantSpousePrivate,
                WantSpouseSensitive = dto.WantSpouseSensitive,
                WantSpouseShy = dto.WantSpouseShy,
                WantSpouseSocial = dto.WantSpouseSocial,
                MinimumSpouseAge = dto.MinimumSpouseAge,
                MaximumSpouseAge = dto.MaximumSpouseAge,
                SpouseMaritalStatuses = dto.SpouseMaritalStatuses,
                ConsiderSpouseWithChildren = dto.ConsiderSpouseWithChildren,
                LookingForInSpouse = dto.LookingForInSpouse,
                DoYouHaveAWali = dto.DoYouHaveAWali,
                WaliName = dto.WaliName,
                WaliEmail = dto.WaliEmail,
                WaliPhone = dto.WaliPhone,
                WaliRelationship = dto.WaliRelationship,
                Gender = dto.Gender
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static HealthViewModel Map(ProfileHealthDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new HealthViewModel()
            {
                ProfileId = dto.ProfileId,
                HaveHealthIssues = dto.HaveHealthIssues,
                HealthIssues = dto.HealthIssues,
                PhysicalImpediments = dto.PhysicalImpediments
            };

            return MapSimpleProfile(viewModel, dto);

        }
        internal static FamilyViewModel Map(ProfileFamilyDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new FamilyViewModel()
            {
                ProfileId = dto.ProfileId,
                LiveWithFamilyPostMarriage = dto.LiveWithFamilyPostMarriage,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static FinanceViewModel Map(ProfileFinanceDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new FinanceViewModel()
            {
                ProfileId = dto.ProfileId,
                FinancesHandlingAfterMarriage = dto.FinancesHandlingAfterMarriage,
                WifeContributeFinancially = dto.WifeContributeFinancially,
                HusbandSoleProvider = dto.HusbandSoleProvider,
                WantToWorkAfterMarriage = dto.WantToWorkAfterMarriage,
                WantWifeToWorkAfterMarriage = dto.WantWifeToWorkAfterMarriage,
                HasDebts = dto.HasDebts,
                Gender = dto.Gender,
            };

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ContactViewModel Map(ProfileContactDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException();
            var viewModel = new ContactViewModel()
            {
                ProfileId = dto.ProfileId,
                BestWayToContact = dto.BestWayToContact,
                ShareInfoWithMatches = dto.ShareInfoWithMatches,
                HasDomesticViolenceHistory = dto.HasDomesticViolenceHistory,
            };

            return MapSimpleProfile(viewModel, dto);
        }


        internal static ProfilePersonalDto Map(PersonalViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfilePersonalDto()
            {
                ProfileId = viewModel.ProfileId,
                DateOfBirth = viewModel.DateOfBirth,
                AddressLine1 = viewModel.AddressLine1,
                AddressLine2 = viewModel.AddressLine2,
                City = viewModel.City,
                State = viewModel.State,
                ZipCode = viewModel.ZipCode,
                LegalStatus = viewModel.LegalStatus,
                Ethnicity = viewModel.Ethnicity,
                PrimaryLanguages = viewModel.PrimaryLanguages,
                PreferredLanguage = viewModel.PreferredLanguage
            };
        }
        internal static ProfilePicturesDto Map(ProfilePicturesViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            ProfilePicturesDto dto = new ProfilePicturesDto();
            dto.ProfileId = viewModel.ProfileId; 
            foreach (PictureViewModel pictureViewModel in viewModel.pictures)
            {
                var tempDto = new PictureDto()
                {
                    ProfilePictureId = pictureViewModel.ProfileId,
                    PictureUri = pictureViewModel.PictureUri,
                    SasToken = pictureViewModel.SasToken,
                    PictureNumber = pictureViewModel.PictureNumber,
                    ProfileId = pictureViewModel.ProfileId
                };
                dto.pictures.Add(tempDto);
            }
            return dto;
        }
        internal static ProfileEducationalProfessionalDto Map(EducationalProfessionalViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileEducationalProfessionalDto()
            {
                ProfileId = viewModel.ProfileId,
                Education = viewModel.Education,
                Occupation = viewModel.Occupation,
            };
        }
        internal static ProfileMaritalDto Map(MaritalViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileMaritalDto()
            {
                ProfileId = viewModel.ProfileId,
                MaritalStatus = viewModel.MaritalStatus,
                HasChildren = viewModel.HasChildren,
                NumberOfChildren = viewModel.NumberOfChildren
            };
        }
        internal static ProfileReligionDto Map(ReligionViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileReligionDto()
            {
                ProfileId = viewModel.ProfileId,
                ReligionImportance = viewModel.ReligionImportance,
                DoYouPray5Times = viewModel.DoYouPray5Times,
                WearsHijab = viewModel.WearsHijab,
                HasBeard = viewModel.HasBeard
            };
        }
        internal static ProfileAboutDto Map(AboutViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileAboutDto()
            {
                ProfileId = viewModel.ProfileId,
                ActiveEnergetic = viewModel.ActiveEnergetic,
                Adaptable = viewModel.Adaptable,
                Sensitive = viewModel.Sensitive,
                Flexible = viewModel.Flexible,
                LaidBack = viewModel.LaidBack,
                Patient = viewModel.Patient,
                Practical = viewModel.Practical,
                Private = viewModel.Private,
                Shy = viewModel.Shy,
                Social = viewModel.Social,
                ShareAboutYourself = viewModel.ShareAboutYourself,
                DescribeTypicalDay = viewModel.DescribeTypicalDay,
                ShortTermGoals = viewModel.ShortTermGoals,
                LongTermGoals = viewModel.LongTermGoals,
                HobbiesAndActivities = viewModel.HobbiesAndActivities
            };
        }
        internal static ProfileSpouseDto Map(SpouseViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();

            return new ProfileSpouseDto()
            {
                ProfileId = viewModel.ProfileId,
                WantSpouseActiveEnergetic = viewModel.WantSpouseActiveEnergetic,
                WantSpouseAdaptable = viewModel.WantSpouseAdaptable,
                WantSpouseFlexible = viewModel.WantSpouseFlexible,
                WantSpouseLaidBack = viewModel.WantSpouseLaidBack,
                WantSpousePatient = viewModel.WantSpousePatient,
                WantSpousePractical = viewModel.WantSpousePractical,
                WantSpousePrivate = viewModel.WantSpousePrivate,
                WantSpouseSensitive = viewModel.WantSpouseSensitive,
                WantSpouseShy = viewModel.WantSpouseShy,
                WantSpouseSocial = viewModel.WantSpouseSocial,
                MinimumSpouseAge = viewModel.MinimumSpouseAge,
                MaximumSpouseAge = viewModel.MaximumSpouseAge,
                SpouseMaritalStatuses = viewModel.SpouseMaritalStatuses,
                ConsiderSpouseWithChildren = viewModel.ConsiderSpouseWithChildren,
                LookingForInSpouse = viewModel.LookingForInSpouse,
                DoYouHaveAWali = viewModel.DoYouHaveAWali,
                WaliName = viewModel.WaliName,
                WaliEmail = viewModel.WaliEmail,
                WaliPhone = viewModel.WaliPhone,
                WaliRelationship = viewModel.WaliRelationship
            };
        }
        internal static ProfileHealthDto Map(HealthViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileHealthDto()
            {
                ProfileId = viewModel.ProfileId,
                HaveHealthIssues = viewModel.HaveHealthIssues,
                HealthIssues = viewModel.HealthIssues,
                PhysicalImpediments = viewModel.PhysicalImpediments,
            };
        }
        internal static ProfileFamilyDto Map(FamilyViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileFamilyDto()
            {
                ProfileId = viewModel.ProfileId,
                LiveWithFamilyPostMarriage = viewModel.LiveWithFamilyPostMarriage,
            };
        }
        internal static ProfileFinanceDto Map(FinanceViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileFinanceDto()
            {
                ProfileId = viewModel.ProfileId,
                FinancesHandlingAfterMarriage = viewModel.FinancesHandlingAfterMarriage,
                WifeContributeFinancially = viewModel.WifeContributeFinancially,
                HusbandSoleProvider = viewModel.HusbandSoleProvider,
                WantToWorkAfterMarriage = viewModel.WantToWorkAfterMarriage,
                WantWifeToWorkAfterMarriage = viewModel.WantWifeToWorkAfterMarriage,
                HasDebts = viewModel.HasDebts,
            };
        }
        internal static ProfileContactDto Map(ContactViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException();
            return new ProfileContactDto()
            {
                ProfileId = viewModel.ProfileId,
                BestWayToContact = viewModel.BestWayToContact,
                ShareInfoWithMatches = viewModel.ShareInfoWithMatches,
                HasDomesticViolenceHistory = viewModel.HasDomesticViolenceHistory,
            };
        }

        internal static PersonalViewModel Map(PersonalViewModel viewModel, ProfilePersonalDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.FullName = $"{dto.FirstName} {dto.LastName}";
            viewModel.Email = dto.Email;
            viewModel.Phone = dto.Phone;

            viewModel.ProfileId = dto.ProfileId;
            viewModel.DateOfBirth = dto.DateOfBirth;
            viewModel.AddressLine1 = dto.AddressLine1;
            viewModel.AddressLine2 = dto.AddressLine2;
            viewModel.City = dto.City;
            viewModel.State = dto.State;
            viewModel.ZipCode = dto.ZipCode;
            viewModel.LegalStatus = dto.LegalStatus;
            viewModel.Ethnicity = dto.Ethnicity;
            viewModel.PrimaryLanguages = dto.PrimaryLanguages;
            viewModel.PreferredLanguage = dto.PreferredLanguage;

            return MapSimpleProfile(viewModel, dto); 
        }
        internal static ProfilePicturesViewModel Map(ProfilePicturesViewModel viewModel, ProfilePicturesDto dto)
        {

            foreach (PictureDto pictureDto in dto.pictures)
            {
                foreach (PictureViewModel pictureViewModel in viewModel.pictures)
                {
                    if (pictureViewModel.PictureNumber == pictureDto.PictureNumber)
                    {
                        pictureViewModel.ProfilePictureId = pictureDto.ProfilePictureId;
                        pictureViewModel.PictureUri = pictureDto.PictureUri;
                        pictureViewModel.SasToken = pictureDto.SasToken;
                        pictureViewModel.ProfileId = pictureDto.ProfileId;
                    }
                }
            }
            return MapSimpleProfile(viewModel, dto);
        }
        internal static EducationalProfessionalViewModel Map(EducationalProfessionalViewModel viewModel, ProfileEducationalProfessionalDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.Education = dto.Education;
            viewModel.Occupation = dto.Occupation;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static MaritalViewModel Map(MaritalViewModel viewModel, ProfileMaritalDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.MaritalStatus = dto.MaritalStatus;
            viewModel.HasChildren = dto.HasChildren;
            viewModel.NumberOfChildren = dto.NumberOfChildren;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ReligionViewModel Map(ReligionViewModel viewModel, ProfileReligionDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.ReligionImportance = dto.ReligionImportance;
            viewModel.DoYouPray5Times = dto.DoYouPray5Times;
            viewModel.WearsHijab = dto.WearsHijab;
            viewModel.HasBeard = dto.HasBeard;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static AboutViewModel Map(AboutViewModel viewModel, ProfileAboutDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.ActiveEnergetic = dto.ActiveEnergetic;
            viewModel.Adaptable = dto.Adaptable;
            viewModel.Sensitive = dto.Sensitive;
            viewModel.Flexible = dto.Flexible;
            viewModel.LaidBack = dto.LaidBack;
            viewModel.Patient = dto.Patient;
            viewModel.Practical = dto.Practical;
            viewModel.Private = dto.Private;
            viewModel.Shy = dto.Shy;
            viewModel.Social = dto.Social;
            viewModel.ShareAboutYourself = dto.ShareAboutYourself;
            viewModel.DescribeTypicalDay = dto.DescribeTypicalDay;
            viewModel.ShortTermGoals = dto.ShortTermGoals;
            viewModel.LongTermGoals = dto.LongTermGoals;
            viewModel.HobbiesAndActivities = dto.HobbiesAndActivities;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static SpouseViewModel Map(SpouseViewModel viewModel, ProfileSpouseDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.WantSpouseActiveEnergetic = dto.WantSpouseActiveEnergetic;
            viewModel.WantSpouseAdaptable = dto.WantSpouseAdaptable;
            viewModel.WantSpouseFlexible = dto.WantSpouseFlexible;
            viewModel.WantSpouseLaidBack = dto.WantSpouseLaidBack;
            viewModel.WantSpousePatient = dto.WantSpousePatient;
            viewModel.WantSpousePractical = dto.WantSpousePractical;
            viewModel.WantSpousePrivate = dto.WantSpousePrivate;
            viewModel.WantSpouseSensitive = dto.WantSpouseSensitive;
            viewModel.WantSpouseShy = dto.WantSpouseShy;
            viewModel.WantSpouseSocial = dto.WantSpouseSocial;
            viewModel.MinimumSpouseAge = dto.MinimumSpouseAge;
            viewModel.MaximumSpouseAge = dto.MaximumSpouseAge;
            viewModel.SpouseMaritalStatuses = dto.SpouseMaritalStatuses;
            viewModel.ConsiderSpouseWithChildren = dto.ConsiderSpouseWithChildren;
            viewModel.LookingForInSpouse = dto.LookingForInSpouse;
            viewModel.DoYouHaveAWali = dto.DoYouHaveAWali;
            viewModel.WaliName = dto.WaliName;
            viewModel.WaliEmail = dto.WaliEmail;
            viewModel.WaliPhone = dto.WaliPhone;
            viewModel.WaliRelationship = dto.WaliRelationship;
            viewModel.Gender = dto.Gender;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static HealthViewModel Map(HealthViewModel viewModel, ProfileHealthDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.HaveHealthIssues = dto.HaveHealthIssues;
            viewModel.HealthIssues = dto.HealthIssues;
            viewModel.PhysicalImpediments = dto.PhysicalImpediments;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static FamilyViewModel Map(FamilyViewModel viewModel, ProfileFamilyDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.LiveWithFamilyPostMarriage = dto.LiveWithFamilyPostMarriage;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static FinanceViewModel Map(FinanceViewModel viewModel, ProfileFinanceDto dto)
        {
            viewModel.ProfileId = dto.ProfileId;
            viewModel.FinancesHandlingAfterMarriage = dto.FinancesHandlingAfterMarriage;
            viewModel.WifeContributeFinancially = dto.WifeContributeFinancially;
            viewModel.HusbandSoleProvider = dto.HusbandSoleProvider;
            viewModel.WantToWorkAfterMarriage = dto.WantToWorkAfterMarriage;
            viewModel.WantWifeToWorkAfterMarriage = dto.WantWifeToWorkAfterMarriage;
            viewModel.HasDebts = dto.HasDebts;

            return MapSimpleProfile(viewModel, dto);
        }
        internal static ContactViewModel Map(ContactViewModel viewModel, ProfileContactDto dto)
        {
            viewModel.BestWayToContact = dto.BestWayToContact;
            viewModel.ShareInfoWithMatches = dto.ShareInfoWithMatches;
            viewModel.HasDomesticViolenceHistory = dto.HasDomesticViolenceHistory;

            return MapSimpleProfile(viewModel, dto);
        }

        internal static List<ProfileResultViewModel> MapMini(IQueryable<AdminProfile> profiles)
        {
            var results = new List<ProfileResultViewModel>();
            foreach (var profile in profiles)
            {
                var result = new ProfileResultViewModel
                {
                    Age = AgeHelper.Calculate(profile.DateOfBirth).GetValueOrDefault(),
                    ShareAboutYourself = profile.ShareAboutYourself,
                    City = profile.City,
                    State = profile.State,
                    ProfileId = profile.ProfileId,
                };

                results.Add(result);
            }

            return results;
        }
    }
}
