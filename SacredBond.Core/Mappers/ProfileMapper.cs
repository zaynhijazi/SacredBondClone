using SacredBond.Common.DTOs;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
using Stripe;

namespace SacredBond.Core.Mappers
{
    internal static class ProfileMapper
    {
        internal static SimpleProfileDto MapSimpleProfile(Profile profile)
        {
            return MapSimpleProfile(new SimpleProfileDto(), profile);
        }

        internal static T MapSimpleProfile<T>(T dto, Profile profile) where T : SimpleProfileDto
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));


            dto.ProfileId = profile.ProfileId;
            dto.Status = profile.Status;
            dto.StatusChangedDate = profile.StatusChangedDate;
            dto.ApprovedDate = profile.ApprovedDate;
            dto.SubmittedDate = profile.SubmittedDate;
            dto.RejectedDate = profile.RejectedDate;
            dto.RejectReason = profile.RejectReason;
            dto.IsAboutCompleted = profile.IsAboutCompleted;
            dto.IsContactCompleted = profile.IsContactCompleted;
            dto.IsEducationalProfessionalCompleted = profile.IsEducationalProfessionalCompleted;
            dto.IsFamilyCompleted = profile.IsFamilyCompleted;
            dto.IsFinanceCompleted = profile.IsFinanceCompleted;
            dto.IsHealthCompleted = profile.IsHealthCompleted;
            dto.IsMaritalCompleted = profile.IsMaritalCompleted;
            dto.IsPicturesCompleted = profile.IsPicturesCompleted;
            dto.IsPersonalCompleted = profile.IsPersonalCompleted;
            dto.IsReligionCompleted = profile.IsReligionCompleted;
            dto.IsSpouseCompleted = profile.IsSpouseCompleted;

            return dto;
        }

        internal static ProfilePersonalDto MapPersonal(User user, Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfilePersonalDto()
            {
                ProfileId = profile.ProfileId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Gender = user.Gender,
                DateOfBirth = profile.DateOfBirth,
                AddressLine1 = profile.AddressLine1,
                AddressLine2 = profile.AddressLine2,
                City = profile.City,
                State = profile.State,
                ZipCode = profile.ZipCode,
                LegalStatus = profile.LegalStatus,
                Ethnicity = profile.Ethnicity,
                PreferredLanguage = profile.PreferredLanguage
            };
            if (profile.ProfileLanguages != null)
            {
                dto.PrimaryLanguages = profile.ProfileLanguages.Select(l => (LanguagesEnum)l.LanguageId).ToList();
            }

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfilePicturesDto MapPictures(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));
            var dto = new ProfilePicturesDto();
            dto.ProfileId = profile.ProfileId;
            var profilePicturesLen = profile.ProfilePictures.ToList().Count;
            if (profilePicturesLen == 0)
            {
                //This is the case where we have no pictures in the database
                for (int i = 1; i < 4; i++)
                {
                    var tempDto = new PictureDto()
                    {
                        PictureNumber = i,
                        ProfileId = profile.ProfileId
                    };
                    dto.pictures.Add(tempDto);
                }
                return MapSimpleProfile(dto, profile);
            }
  
            foreach (ProfilePicture picture in profile.ProfilePictures)
            {
                var tempDto = new PictureDto()
                {
                    ProfilePictureId = picture.ProfilePictureId,
                    PictureUri = picture.PictureUri,
                    SasToken = picture.SasToken,
                    PictureNumber = picture.PictureNumber,
                    ProfileId = picture.ProfileId
                };
                dto.pictures.Add(tempDto);
            }
            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileEducationalProfessionalDto MapEducationalProfessional(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileEducationalProfessionalDto()
            {
                ProfileId = profile.ProfileId,
                Education = profile.Education,
                Occupation = profile.Occupation
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileMaritalDto MapMarital(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileMaritalDto()
            {
                ProfileId = profile.ProfileId,
                MaritalStatus = profile.MaritalStatus,
                HasChildren = profile.HasChildren,
                NumberOfChildren = profile.NumberOfChildren
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileReligionDto MapReligion(User user, Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileReligionDto()
            {
                ProfileId = profile.ProfileId,
                ReligionImportance = profile.ReligionImportance,
                DoYouPray5Times = profile.DoYouPray5Times,
                WearsHijab = profile.WearsHijab,
                HasBeard = profile.HasBeard,
                Gender = user.Gender,
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileAboutDto MapAbout(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileAboutDto()
            {
                ProfileId = profile.ProfileId,
                ActiveEnergetic = profile.ActiveEnergetic,
                Adaptable = profile.Adaptable,
                Sensitive = profile.Sensitive,
                Flexible = profile.Flexible,
                LaidBack = profile.LaidBack,
                Patient = profile.Patient,
                Practical = profile.Practical,
                Private = profile.Private,
                Shy = profile.Shy,
                Social = profile.Social,
                ShareAboutYourself = profile.ShareAboutYourself,
                DescribeTypicalDay = profile.DescribeTypicalDay,
                ShortTermGoals = profile.ShortTermGoals,
                LongTermGoals = profile.LongTermGoals,
                HobbiesAndActivities = profile.HobbiesAndActivities
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileSpouseDto MapSpouse(User user, Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileSpouseDto()
            {
                ProfileId = profile.ProfileId,
                WantSpouseActiveEnergetic = profile.WantSpouseActiveEnergetic,
                WantSpouseAdaptable = profile.WantSpouseAdaptable,
                WantSpouseFlexible = profile.WantSpouseFlexible,
                WantSpouseLaidBack = profile.WantSpouseLaidBack,
                WantSpousePatient = profile.WantSpousePatient,
                WantSpousePractical = profile.WantSpousePractical,
                WantSpousePrivate = profile.WantSpousePrivate,
                WantSpouseSensitive = profile.WantSpouseSensitive,
                WantSpouseShy = profile.WantSpouseShy,
                WantSpouseSocial = profile.WantSpouseSocial,
                MinimumSpouseAge = profile.MinimumSpouseAge,
                MaximumSpouseAge = profile.MaximumSpouseAge,
                SpouseMaritalStatuses = (SpouseMaritalStatuses?)profile.SpouseMaritalStatusesId,
                ConsiderSpouseWithChildren = profile.ConsiderSpouseWithChildren,
                LookingForInSpouse = profile.LookingForInSpouse,
                DoYouHaveAWali = profile.DoYouHaveAWali,
                WaliName = profile.WaliName,
                WaliEmail = profile.WaliEmail,
                WaliPhone = profile.WaliPhone,
                WaliRelationship = profile.WaliRelationship,
                Gender = user.Gender
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileHealthDto MapHealth(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileHealthDto()
            {
                ProfileId = profile.ProfileId,
                HaveHealthIssues = profile.HaveHealthIssues,
                HealthIssues = profile.HealthIssues,
                PhysicalImpediments = profile.PhysicalImpediments
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileFamilyDto MapFamily(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileFamilyDto()
            {
                ProfileId = profile.ProfileId,
                LiveWithFamilyPostMarriage = profile.LiveWithFamilyPostMarriage,
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileFinanceDto MapFinance(User user, Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileFinanceDto()
            {
                ProfileId = profile.ProfileId,
                FinancesHandlingAfterMarriage = profile.FinancesHandlingAfterMarriage,
                WifeContributeFinancially = profile.WifeContributeFinancially,
                HusbandSoleProvider = profile.HusbandSoleProvider,
                WantToWorkAfterMarriage = profile.WantToWorkAfterMarriage,
                WantWifeToWorkAfterMarriage = profile.WantWifeToWorkAfterMarriage,
                HasDebts = profile.HasDebts,
                Gender = user.Gender
            };

            return MapSimpleProfile(dto, profile);
        }
        internal static ProfileContactDto MapContact(Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileContactDto()
            {
                ProfileId=profile.ProfileId,
                BestWayToContact = profile.BestWayToContact,
                ShareInfoWithMatches = profile.ShareInfoWithMatches,
                HasDomesticViolenceHistory = profile.HasDomesticViolenceHistory,
            };

            return MapSimpleProfile(dto, profile);
        }

        internal static Profile Map(Profile profile, ProfilePersonalDto dto)
        {
            profile.DateOfBirth = dto.DateOfBirth;
            profile.AddressLine1 = dto.AddressLine1;
            profile.AddressLine2 = dto.AddressLine2;
            profile.City = dto.City;
            profile.State = dto.State;
            profile.ZipCode = dto.ZipCode;
            profile.LegalStatus = dto.LegalStatus;
            profile.Ethnicity = dto.Ethnicity;
            profile.PreferredLanguage = dto.PreferredLanguage;
            return profile;
        }
        //internal static Profile Map(Profile profile, ProfilePicturesDto dto)
        //{
        //  //I have not done anything as of yet, still figuring things out

        //    return profile;
        //}
        internal static Profile Map(Profile profile, ProfileEducationalProfessionalDto dto)
        {
            profile.Education = dto.Education;
            profile.Occupation = dto.Occupation;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileMaritalDto dto)
        {
            profile.MaritalStatus = dto.MaritalStatus;
            profile.HasChildren = dto.HasChildren;
            profile.NumberOfChildren = dto.NumberOfChildren;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileReligionDto dto)
        {
            profile.ReligionImportance = dto.ReligionImportance;
            profile.DoYouPray5Times = dto.DoYouPray5Times;
            profile.WearsHijab = dto.WearsHijab;
            profile.HasBeard = dto.HasBeard;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileAboutDto dto)
        {
            profile.ActiveEnergetic = dto.ActiveEnergetic;
            profile.Adaptable = dto.Adaptable;
            profile.Sensitive = dto.Sensitive;
            profile.Flexible = dto.Flexible;
            profile.LaidBack = dto.LaidBack;
            profile.Patient = dto.Patient;
            profile.Practical = dto.Practical;
            profile.Private = dto.Private;
            profile.Shy = dto.Shy;
            profile.Social = dto.Social;
            profile.ShareAboutYourself = dto.ShareAboutYourself;
            profile.DescribeTypicalDay = dto.DescribeTypicalDay;
            profile.ShortTermGoals = dto.ShortTermGoals;
            profile.LongTermGoals = dto.LongTermGoals;
            profile.HobbiesAndActivities = dto.HobbiesAndActivities;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileSpouseDto dto)
        {
            profile.WantSpouseActiveEnergetic = dto.WantSpouseActiveEnergetic;
            profile.WantSpouseAdaptable = dto.WantSpouseAdaptable;
            profile.WantSpouseFlexible = dto.WantSpouseFlexible;
            profile.WantSpouseLaidBack = dto.WantSpouseLaidBack;
            profile.WantSpousePatient = dto.WantSpousePatient;
            profile.WantSpousePractical = dto.WantSpousePractical;
            profile.WantSpousePrivate = dto.WantSpousePrivate;
            profile.WantSpouseSensitive = dto.WantSpouseSensitive;
            profile.WantSpouseShy = dto.WantSpouseShy;
            profile.WantSpouseSocial = dto.WantSpouseSocial;
            profile.MinimumSpouseAge = dto.MinimumSpouseAge;
            profile.MaximumSpouseAge = dto.MaximumSpouseAge;
            profile.SpouseMaritalStatusesId = dto.SpouseMaritalStatuses;
            profile.ConsiderSpouseWithChildren = dto.ConsiderSpouseWithChildren;
            profile.LookingForInSpouse = dto.LookingForInSpouse;
            profile.DoYouHaveAWali = dto.DoYouHaveAWali;
            profile.WaliName = dto.WaliName;
            profile.WaliEmail = dto.WaliEmail;
            profile.WaliPhone = dto.WaliPhone;
            profile.WaliRelationship = dto.WaliRelationship;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileHealthDto dto)
        {
            profile.HaveHealthIssues = dto.HaveHealthIssues;
            profile.HealthIssues = dto.HealthIssues;
            profile.PhysicalImpediments = dto.PhysicalImpediments;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileFamilyDto dto)
        {
            profile.LiveWithFamilyPostMarriage = dto.LiveWithFamilyPostMarriage;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileFinanceDto dto)
        {
            profile.FinancesHandlingAfterMarriage = dto.FinancesHandlingAfterMarriage;
            profile.WifeContributeFinancially = dto.WifeContributeFinancially;
            profile.HusbandSoleProvider = dto.HusbandSoleProvider;
            profile.WantToWorkAfterMarriage = dto.WantToWorkAfterMarriage;
            profile.WantWifeToWorkAfterMarriage = dto.WantWifeToWorkAfterMarriage;
            profile.HasDebts = dto.HasDebts;
            return profile;
        }
        internal static Profile Map(Profile profile, ProfileContactDto dto)
        {
            profile.BestWayToContact = dto.BestWayToContact;
            profile.ShareInfoWithMatches = dto.ShareInfoWithMatches;
            profile.HasDomesticViolenceHistory = dto.HasDomesticViolenceHistory;
            return profile;
        }

        internal static ProfileDto MapFullProfile(User user, Profile profile)
        {
            if (profile == null)
                throw new ArgumentNullException(nameof(profile));

            var dto = new ProfileDto()
            {
                Personal = MapPersonal(user, profile),
                EducationalProfessional = MapEducationalProfessional(profile),
                Marital = MapMarital(profile),
                Religion = MapReligion(user, profile),
                About = MapAbout(profile),
                Spouse = MapSpouse(user, profile),
                Health = MapHealth(profile),
                Family = MapFamily(profile),
                Finance = MapFinance(user, profile),
                Contact = MapContact(profile)
            };

            return MapSimpleProfile(dto, profile);
        }
    }
}
