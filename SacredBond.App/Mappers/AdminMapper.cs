using SacredBond.App.Models.Admin;
using SacredBond.App.Models.Matches;
using SacredBond.Common.DTOs;
using SacredBond.Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SacredBond.App.Mappers
{
    public static class AdminMapper
    {
        public static List<AdminProfileViewModel> Map(List<AdminProfile> adminProfiles)
        {
            List<AdminProfileViewModel> profiles = new List<AdminProfileViewModel>();

            foreach (var profile in adminProfiles)
            {
                profiles.Add(new AdminProfileViewModel()
                {
                    PersonalViewModel = new Models.Profile.PersonalViewModel
                    {
                        ProfileId = profile.ProfileId,
                        Email = profile.Email,
                        FullName = profile.FullName,
                        Gender = profile.Gender,
                        Phone = profile.PhoneNumber,
                        CreateTime = profile.CreateTime,
                        SubmittedDate = profile.SubmittedDate,
                        RejectedDate = profile.RejectedDate,
                        ApprovedDate = profile.ApprovedDate,
                        StatusChangedDate = profile.StatusChangedDate
                    }
                });
            }

            return profiles;
        }

        public static List<MatchViewModel> Map(List<MatchDto> matchDtos)
        {
            List<MatchViewModel> matchViewModels = new List<MatchViewModel>();

            foreach (var item in matchDtos)
            {
                var match = new MatchViewModel();
                match.MatchId = item.MatchId;

                if (item.ProfileId > 0)
                {
                    match.ProfileId = item.ProfileId;
                    match.ProfileUserFullName = item.ProfileUserFirstName + " " + item.ProfileUserLastName;
                    match.ProfileUserGender = item.ProfileUserGender;
                    match.ProfileUserEmail = item.ProfileUserEmail;
                    match.ProfileUserPhone = item.ProfileUserPhone;
                }

                if (item.SpouseId > 0)
                {
                    match.SpouseId = item.SpouseId;
                    match.SpouseUserFullName = item.SpouseUserFirstName + " " + item.SpouseUserLastName;
                    match.SpouseUserGender = item.SpouseUserGender;
                    match.SpouseUserEmail = item.SpouseUserEmail;
                    match.SpouseUserPhone = item.SpouseUserPhone;
                }

                match.Status = item.Status.Value;
                match.StatusChangedDate = item.StatusChangedDate ?? DateTime.MinValue;
                match.ApprovedDate = item.ApprovedDate;
                match.RejectedDate = item.RejectedDate;
                match.ReviewedDate = item.ReviewedDate;
                match.CompletedDate = item.CompletedDate;

                matchViewModels.Add(match);
            }

            return matchViewModels;
        }
        private static AdminProfileViewModel MapPublicData(AdminProfile adminProfile)
        {
            if (adminProfile == null)
            {
                throw new Exception("Unable to find profile");
            }

            AdminProfileViewModel profile = new AdminProfileViewModel();
            profile.languages = adminProfile.Languages;

            profile.PersonalViewModel = new Models.Profile.PersonalViewModel()
            {
                Status = adminProfile.Status,
                Gender = adminProfile.Gender,
                Email = adminProfile.Email,
            };

            profile.EducationalProfessionalViewModel = new Models.Profile.EducationalProfessionalViewModel()
            {
                Education = adminProfile.Education,
                Occupation = adminProfile.Occupation
            };

            profile.MaritalViewModel = new Models.Profile.MaritalViewModel()
            {
                MaritalStatus = adminProfile.MaritalStatus,
                HasChildren = adminProfile.HasChildren,
                NumberOfChildren = adminProfile.NumberOfChildren,
            };

            profile.ReligionViewModel = new Models.Profile.ReligionViewModel()
            {
                ReligionImportance = adminProfile.ReligionImportance,
                DoYouPray5Times = adminProfile.DoYouPray5Times,
                WearsHijab = adminProfile.WearsHijab,
                HasBeard = adminProfile.HasBeard,
            };

            profile.SpouseViewModel = new Models.Profile.SpouseViewModel()
            {
                WantSpouseActiveEnergetic = adminProfile.WantSpouseActiveEnergetic,
                WantSpouseAdaptable = adminProfile.WantSpouseAdaptable,
                WantSpouseSensitive = adminProfile.WantSpouseSensitive,
                WantSpouseFlexible = adminProfile.WantSpouseFlexible,
                WantSpouseLaidBack = adminProfile.WantSpouseLaidBack,
                WantSpousePatient = adminProfile.WantSpousePatient,
                WantSpousePractical = adminProfile.WantSpousePractical,
                WantSpousePrivate = adminProfile.WantSpousePrivate,
                WantSpouseShy = adminProfile.WantSpouseShy,
                WantSpouseSocial = adminProfile.WantSpouseSocial,
                SpouseMaritalStatuses = adminProfile.SpouseMaritalStatusesId,
                MinimumSpouseAge = adminProfile.MinimumSpouseAge,
                MaximumSpouseAge = adminProfile.MaximumSpouseAge,
                ConsiderSpouseWithChildren = adminProfile.ConsiderSpouseWithChildren,
                LookingForInSpouse = adminProfile.LookingForInSpouse,
                DoYouHaveAWali = adminProfile.DoYouHaveAWali,
                WaliName = adminProfile.WaliName,
                WaliRelationship = adminProfile.WaliRelationship,
                WaliEmail = adminProfile.WaliEmail,
                WaliPhone = adminProfile.WaliPhone,
            };

            profile.ContactViewModel = new Models.Profile.ContactViewModel()
            {
                BestWayToContact = adminProfile.BestWayToContact,
                ShareInfoWithMatches = adminProfile.ShareInfoWithMatches,
                HasDomesticViolenceHistory = adminProfile.HasDomesticViolenceHistory,
            };

            profile.FamilyViewModel = new Models.Profile.FamilyViewModel()
            {
                LiveWithFamilyPostMarriage = adminProfile.LiveWithFamilyPostMarriage,
            };

            profile.FinanceViewModel = new Models.Profile.FinanceViewModel()
            {
                FinancesHandlingAfterMarriage = adminProfile.FinancesHandlingAfterMarriage,
                WifeContributeFinancially = adminProfile.WifeContributeFinancially,
                HusbandSoleProvider = adminProfile.HusbandSoleProvider,
                WantToWorkAfterMarriage = adminProfile.WantToWorkAfterMarriage,
                WantWifeToWorkAfterMarriage = adminProfile.WantWifeToWorkAfterMarriage,
                HasDebts = adminProfile.HasDebts,
            };

            profile.HealthViewModel = new Models.Profile.HealthViewModel()
            {
                PhysicalImpediments = adminProfile.PhysicalImpediments,
                HaveHealthIssues = adminProfile.HaveHealthIssues,
                HealthIssues = adminProfile.HealthIssues,
            };

            profile.AboutViewModel = new Models.Profile.AboutViewModel()
            {
                ActiveEnergetic = adminProfile.ActiveEnergetic,
                Adaptable = adminProfile.Adaptable,
                Sensitive = adminProfile.Sensitive,
                Flexible = adminProfile.Flexible,
                LaidBack = adminProfile.LaidBack,
                Patient = adminProfile.Patient,
                Practical = adminProfile.Practical,
                Private = adminProfile.Private,
                Shy = adminProfile.Shy,
                Social = adminProfile.Social,
                ShareAboutYourself = adminProfile.ShareAboutYourself,
                DescribeTypicalDay = adminProfile.DescribeTypicalDay,
                HobbiesAndActivities = adminProfile.HobbiesAndActivities,
                ShortTermGoals = adminProfile.ShortTermGoals,
                LongTermGoals = adminProfile.LongTermGoals,
            };

            return profile;
        }
        public static AdminProfileViewModel Map(AdminProfile adminProfile)
        {
            var profile = MapPublicData(adminProfile);

            profile.PersonalViewModel.ProfileId = adminProfile.ProfileId;
            profile.PersonalViewModel.Status = adminProfile.Status;
            profile.PersonalViewModel.Email = adminProfile.Email;
            profile.PersonalViewModel.FullName = $"{adminProfile.FirstName} {adminProfile.LastName}";
            profile.PersonalViewModel.Gender = adminProfile.Gender;
            profile.PersonalViewModel.Phone = adminProfile.PhoneNumber;
            profile.PersonalViewModel.DateOfBirth = adminProfile.DateOfBirth;
            profile.PersonalViewModel.AddressLine1 = adminProfile.AddressLine1;
            profile.PersonalViewModel.AddressLine2 = adminProfile.AddressLine2;
            profile.PersonalViewModel.City = adminProfile.City;
            profile.PersonalViewModel.State = adminProfile.State;
            profile.PersonalViewModel.ZipCode = adminProfile.ZipCode;
            profile.PersonalViewModel.LegalStatus = adminProfile.LegalStatus;
            profile.PersonalViewModel.Ethnicity = adminProfile.Ethnicity;
            profile.PersonalViewModel.PreferredLanguage = adminProfile.PreferredLanguage;
            profile.PersonalViewModel.CreateTime = adminProfile.CreateTime;
            profile.PersonalViewModel.SubmittedDate = adminProfile.SubmittedDate;
            profile.PersonalViewModel.RejectedDate = adminProfile.RejectedDate;  
            profile.PersonalViewModel.ApprovedDate = adminProfile.ApprovedDate;
            profile.PersonalViewModel.StatusChangedDate = adminProfile.StatusChangedDate;

            return profile;
        }

        public static ProfileSingleMatchViewModel Map(AdminProfile adminProfile, ProfileMatches profileMatch)
        {
            var spouseProfile = MapPublicData(adminProfile);
            ProfileSingleMatchViewModel viewModel = new ProfileSingleMatchViewModel();

            if (spouseProfile != null)
            {
                viewModel.AboutViewModel = spouseProfile.AboutViewModel;
                viewModel.PersonalViewModel = spouseProfile.PersonalViewModel;
                viewModel.SpouseViewModel = spouseProfile.SpouseViewModel;
                viewModel.ContactViewModel = spouseProfile.ContactViewModel;
                viewModel.HealthViewModel = spouseProfile.HealthViewModel;
                viewModel.EducationalProfessionalViewModel = spouseProfile.EducationalProfessionalViewModel;
                viewModel.FamilyViewModel = spouseProfile.FamilyViewModel;
                viewModel.FinanceViewModel = spouseProfile.FinanceViewModel;
                viewModel.MaritalViewModel = spouseProfile.MaritalViewModel;
                viewModel.ReligionViewModel = spouseProfile.ReligionViewModel;

                if (profileMatch != null)
                {
                    viewModel.IntrestedInStatus = profileMatch.Status;
                    viewModel.SpouseId = profileMatch.SpouseId;
                }
            }

            return viewModel;
        }

        internal static List<CountDetails> MapCounts(List<CountDetailsDto> countDetailsDto)
        {
            List<CountDetails> countDetailsList = new List<CountDetails>();

            foreach (var item in countDetailsDto)
            {
                countDetailsList.Add(new CountDetails
                {
                    Count = item.Count,
                    Name = item.Name
                });
            }

            return countDetailsList;
        }
    }
}
