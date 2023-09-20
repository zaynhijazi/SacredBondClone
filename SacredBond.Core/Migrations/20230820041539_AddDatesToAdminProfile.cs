using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class AddDatesToAdminProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

/****** Object:  View [dbo].[AdminProfile]    Script Date: 8/20/2023 12:09:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


                                   ALTER VIEW [dbo].[AdminProfile]
                                   AS
                                   SELECT u.FirstName,
                                   u.LastName,
                                   TRIM(u.FirstName) + ' ' + TRIM(u.LastName) AS FullName,
                                   u.UserId,
                                   u.Gender,
                                   CASE Gender
                                       WHEN 1 THEN
                                           'Male'
                                       WHEN 2 THEN
                                           'Female'
                                       ELSE
                                           ''
                                   END AS GenderName,
                                   u.PhoneNumber,
                                   u.Email,
                                   p.ProfileId,
                                   p.Status,
                                   p.WantSpouseActiveEnergetic,
                                   p.WantSpouseAdaptable,
                                   p.WantSpouseSensitive,
                                   p.WantSpouseFlexible,
                                   p.WantSpouseLaidBack,
                                   p.WantSpousePatient,
                                   p.WantSpousePractical,
                                   p.WantSpousePrivate,
                                   p.WantSpouseShy,
                                   p.WantSpouseSocial,
                                   p.SpouseMaritalStatusesId,
                                   p.MinimumSpouseAge,
                                   p.MaximumSpouseAge,
                                   p.ConsiderSpouseWithChildren,
                                   p.LookingForInSpouse,
                                   p.DoYouHaveAWali,
                                   p.WaliName,
                                   p.WaliRelationship,
                                   p.WaliEmail,
                                   p.WaliPhone,
                                   p.BestWayToContact,
                                   p.ShareInfoWithMatches,
                                   p.HasDomesticViolenceHistory,
                                   p.Education,
                                   p.Occupation,
                                   p.LiveWithFamilyPostMarriage,
                                   p.FinancesHandlingAfterMarriage,
                                   p.WifeContributeFinancially,
                                   p.HusbandSoleProvider,
                                   p.WantToWorkAfterMarriage,
                                   p.WantWifeToWorkAfterMarriage,
                                   p.HasDebts,
                                   p.PhysicalImpediments,
                                   p.HaveHealthIssues,
                                   p.HealthIssues,
                                   p.MaritalStatus,
                                   p.HasChildren,
                                   p.NumberOfChildren,
                                   p.DateOfBirth,
                                   p.LegalStatus,
                                   p.Ethnicity,
                                   STUFF(
                                   (
                                       SELECT ',' + l.Name
                                       FROM dbo.ProfileLanguage pl
                                           JOIN dbo.Language l
                                               ON l.Id = pl.LanguageId
                                       WHERE pl.ProfileId = p.ProfileId
                                       FOR XML PATH('')
                                   ),
                                   1,
                                   1,
                                   ''
                                        ) AS languages,
                                   p.PreferredLanguage,
                                   p.AddressLine1,
                                   p.AddressLine2,
                                   p.City,
                                   p.State,
                                   p.ZipCode,
                                   p.ReligionImportance,
                                   p.DoYouPray5Times,
                                   p.WearsHijab,
                                   p.HasBeard,
                                   p.ActiveEnergetic,
                                   p.Adaptable,
                                   p.Sensitive,
                                   p.Flexible,
                                   p.LaidBack,
                                   p.Patient,
                                   p.Practical,
                                   p.Private,
                                   p.Shy,
                                   p.Social,
                                   p.ShareAboutYourself,
                                   p.DescribeTypicalDay,
                                   p.HobbiesAndActivities,
                                   p.ShortTermGoals,
                                   p.LongTermGoals,
								   p.CreateTime,
								   p.SubmittedDate,
								   p.RejectedDate,
								   p.ApprovedDate,
								   p.StatusChangedDate
                            FROM dbo.[User] u
                                INNER JOIN dbo.Profile p
                                    ON p.ProfileId = u.ProfileId
                                LEFT OUTER JOIN dbo.UserRole ur 
		                                ON ur.UserId = u.UserId
                                Where
	                                ur.RoleId IS NULL;
GO

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

/****** Object:  View [dbo].[AdminProfile]    Script Date: 8/20/2023 12:09:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


                                   ALTER VIEW [dbo].[AdminProfile]
                                   AS
                                   SELECT u.FirstName,
                                   u.LastName,
                                   TRIM(u.FirstName) + ' ' + TRIM(u.LastName) AS FullName,
                                   u.UserId,
                                   u.Gender,
                                   CASE Gender
                                       WHEN 1 THEN
                                           'Male'
                                       WHEN 2 THEN
                                           'Female'
                                       ELSE
                                           ''
                                   END AS GenderName,
                                   u.PhoneNumber,
                                   u.Email,
                                   p.ProfileId,
                                   p.Status,
                                   p.WantSpouseActiveEnergetic,
                                   p.WantSpouseAdaptable,
                                   p.WantSpouseSensitive,
                                   p.WantSpouseFlexible,
                                   p.WantSpouseLaidBack,
                                   p.WantSpousePatient,
                                   p.WantSpousePractical,
                                   p.WantSpousePrivate,
                                   p.WantSpouseShy,
                                   p.WantSpouseSocial,
                                   p.SpouseMaritalStatusesId,
                                   p.MinimumSpouseAge,
                                   p.MaximumSpouseAge,
                                   p.ConsiderSpouseWithChildren,
                                   p.LookingForInSpouse,
                                   p.DoYouHaveAWali,
                                   p.WaliName,
                                   p.WaliRelationship,
                                   p.WaliEmail,
                                   p.WaliPhone,
                                   p.BestWayToContact,
                                   p.ShareInfoWithMatches,
                                   p.HasDomesticViolenceHistory,
                                   p.Education,
                                   p.Occupation,
                                   p.LiveWithFamilyPostMarriage,
                                   p.FinancesHandlingAfterMarriage,
                                   p.WifeContributeFinancially,
                                   p.HusbandSoleProvider,
                                   p.WantToWorkAfterMarriage,
                                   p.WantWifeToWorkAfterMarriage,
                                   p.HasDebts,
                                   p.PhysicalImpediments,
                                   p.HaveHealthIssues,
                                   p.HealthIssues,
                                   p.MaritalStatus,
                                   p.HasChildren,
                                   p.NumberOfChildren,
                                   p.DateOfBirth,
                                   p.LegalStatus,
                                   p.Ethnicity,
                                   STUFF(
                                   (
                                       SELECT ',' + l.Name
                                       FROM dbo.ProfileLanguage pl
                                           JOIN dbo.Language l
                                               ON l.Id = pl.LanguageId
                                       WHERE pl.ProfileId = p.ProfileId
                                       FOR XML PATH('')
                                   ),
                                   1,
                                   1,
                                   ''
                                        ) AS languages,
                                   p.PreferredLanguage,
                                   p.AddressLine1,
                                   p.AddressLine2,
                                   p.City,
                                   p.State,
                                   p.ZipCode,
                                   p.ReligionImportance,
                                   p.DoYouPray5Times,
                                   p.WearsHijab,
                                   p.HasBeard,
                                   p.ActiveEnergetic,
                                   p.Adaptable,
                                   p.Sensitive,
                                   p.Flexible,
                                   p.LaidBack,
                                   p.Patient,
                                   p.Practical,
                                   p.Private,
                                   p.Shy,
                                   p.Social,
                                   p.ShareAboutYourself,
                                   p.DescribeTypicalDay,
                                   p.HobbiesAndActivities,
                                   p.ShortTermGoals,
                                   p.LongTermGoals
                                FROM dbo.[User] u
                                INNER JOIN dbo.Profile p
                                    ON p.ProfileId = u.ProfileId;
GO






");
        }
    }
}
