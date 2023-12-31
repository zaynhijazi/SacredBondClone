﻿using Bogus;
using SacredBond.Common.Enums;
using SacredBond.Core.Domain;
public class DataSeeder
{
    public static List<User> SeedUsers(int numberOfUsers)
    {
        Randomizer.Seed = new Random(999999);

        var faker = new Faker<User>()
            .RuleFor(u => u.FirstName, f => f.Person.FirstName)
            .RuleFor(u => u.LastName, f => f.Person.LastName)
            .RuleFor(u => u.Email, f => f.Person.Email)
            .RuleFor(u => u.PhoneNumber, f => f.Person.Phone)
            .RuleFor(u => u.Gender, f => f.PickRandom<Genders>());

        var fakeUsers = faker.Generate(numberOfUsers);
        return fakeUsers;
    }
    public static List<Profile> SeedProfiles(int numberOfUsers)
    {
        var faker = new Faker<Profile>()
        .RuleFor(p => p.Status, f => ProfileStatus.Pending)
       .RuleFor(p => p.StatusChangedDate, f => f.Date.Past())
       .RuleFor(p => p.CreateTime, f => f.Date.Past())
       .RuleFor(p => p.IsPersonalCompleted, f => true)
       .RuleFor(p => p.IsEducationalProfessionalCompleted, f => true)
       .RuleFor(p => p.IsMaritalCompleted, f => true)
       .RuleFor(p => p.IsReligionCompleted, f => true)
       .RuleFor(p => p.IsAboutCompleted, f => true)
       .RuleFor(p => p.IsSpouseCompleted, f => true)
       .RuleFor(p => p.IsHealthCompleted, f => true)
       .RuleFor(p => p.IsFamilyCompleted, f => true)
       .RuleFor(p => p.IsFinanceCompleted, f => true)
       .RuleFor(p => p.IsContactCompleted, f => true)
       .RuleFor(p => p.DateOfBirth, f => f.Date.Between(DateTime.Today.AddYears(-50), DateTime.Today.AddYears(-18)))
       .RuleFor(p => p.AddressLine1, f => f.Address.StreetAddress())
       .RuleFor(p => p.AddressLine2, f => f.Address.SecondaryAddress())
       .RuleFor(p => p.City, f => f.Address.City())
       .RuleFor(p => p.State, f => f.PickRandom<States>())
       .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
       .RuleFor(p => p.LegalStatus, f => f.PickRandom<LegalStatuses>())
       .RuleFor(p => p.Ethnicity, f => f.PickRandom<Ethnicities>())
       .RuleFor(p => p.PreferredLanguage, f => f.PickRandom<LanguagesEnum>())
       .RuleFor(p => p.Education, f => f.PickRandom<EducationLevelsEnum>())
       .RuleFor(p => p.Occupation, f => f.Name.JobTitle())
       .RuleFor(p => p.MaritalStatus, f => f.PickRandom<MaritalStatuses>())
       .RuleFor(p => p.HasChildren, f => f.Random.Bool())
       .RuleFor(p => p.NumberOfChildren, f => f.Random.Int(0, 5))
       .RuleFor(p => p.ReligionImportance, f => f.Lorem.Sentence())
       .RuleFor(p => p.DoYouPray5Times, f => f.Random.Bool())
       .RuleFor(p => p.WearsHijab, f => f.PickRandom<WearsHijabOptions>())
       .RuleFor(p => p.HasBeard, f => f.Random.Bool())
       .RuleFor(p => p.ActiveEnergetic, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Adaptable, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Sensitive, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Flexible, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.LaidBack, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Patient, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Practical, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Private, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Shy, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.Social, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.ShareAboutYourself, f => f.Lorem.Paragraph())
       .RuleFor(p => p.DescribeTypicalDay, f => f.Lorem.Paragraph())
       .RuleFor(p => p.ShortTermGoals, f => f.Lorem.Paragraph())
       .RuleFor(p => p.LongTermGoals, f => f.Lorem.Paragraph())
       .RuleFor(p => p.HobbiesAndActivities, f => f.Lorem.Paragraph())
       .RuleFor(p => p.WantSpouseActiveEnergetic, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseActiveEnergetic, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseAdaptable, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseSensitive, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseFlexible, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseLaidBack, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpousePatient, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpousePractical, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpousePrivate, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseShy, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.WantSpouseSocial, f => f.PickRandom<AllSomeNot>())
       .RuleFor(p => p.MinimumSpouseAge, f => f.Random.Int(18, 50))
       .RuleFor(p => p.MaximumSpouseAge, f => f.Random.Int(50, 80))
       .RuleFor(p => p.SpouseMaritalStatusesId, f => f.PickRandom<SpouseMaritalStatuses>())
       .RuleFor(p => p.ConsiderSpouseWithChildren, f => f.PickRandom<YesNoMaybeOptions>())
       .RuleFor(p => p.LookingForInSpouse, f => f.Lorem.Sentence())
       .RuleFor(p => p.DoYouHaveAWali, f => f.PickRandom<WaliOptions>())
       .RuleFor(p => p.WaliName, f => f.Person.FullName)
       .RuleFor(p => p.WaliRelationship, f => f.Lorem.Word())
       .RuleFor(p => p.WaliPhone, f => f.Phone.PhoneNumber())
       .RuleFor(p => p.WaliEmail, f => f.Person.Email)
       .RuleFor(p => p.HaveHealthIssues, f => f.Random.Bool())
       .RuleFor(p => p.HealthIssues, f => f.Lorem.Sentence())
       .RuleFor(p => p.PhysicalImpediments, f => f.Lorem.Sentence())
       .RuleFor(p => p.LiveWithFamilyPostMarriage, f => f.Lorem.Word())
       .RuleFor(p => p.FinancesHandlingAfterMarriage, f => f.PickRandom<FinancesHandlingAfterMarriageOptions>())
       .RuleFor(p => p.WifeContributeFinancially, f => f.Random.Bool())
       .RuleFor(p => p.HusbandSoleProvider, f => f.Random.Bool())
       .RuleFor(p => p.WantToWorkAfterMarriage, f => f.PickRandom<YesNoMaybeOptions>())
       .RuleFor(p => p.WantWifeToWorkAfterMarriage, f => f.PickRandom<YesNoMaybeOptions>())
       .RuleFor(p => p.HasDebts, f => f.Random.Bool())
       .RuleFor(p => p.BestWayToContact, f => f.PickRandom<ContactMethods>())
       .RuleFor(p => p.ShareInfoWithMatches, f => f.Random.Bool())
       .RuleFor(p => p.HasDomesticViolenceHistory, f => f.PickRandom<YesNoMaybeOptions>());

        var fakeProfiles = faker.Generate(numberOfUsers);
        return fakeProfiles;
    }
}
