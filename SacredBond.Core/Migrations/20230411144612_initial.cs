using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SacredBond.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmittedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPersonalCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEducationalProfessionalCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsMaritalCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsReligionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsAboutCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSpouseCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsHealthCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFamilyCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFinanceCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsContactCompleted = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LegalStatus = table.Column<int>(type: "int", nullable: true),
                    Ethnicity = table.Column<int>(type: "int", nullable: true),
                    PreferredLanguage = table.Column<int>(type: "int", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: true),
                    HasChildren = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfChildren = table.Column<int>(type: "int", nullable: true),
                    ReligionImportance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoYouPray5Times = table.Column<bool>(type: "bit", nullable: true),
                    WearsHijab = table.Column<int>(type: "int", nullable: true),
                    HasBeard = table.Column<bool>(type: "bit", nullable: true),
                    ActiveEnergetic = table.Column<int>(type: "int", nullable: true),
                    Adaptable = table.Column<int>(type: "int", nullable: true),
                    Sensitive = table.Column<int>(type: "int", nullable: true),
                    Flexible = table.Column<int>(type: "int", nullable: true),
                    LaidBack = table.Column<int>(type: "int", nullable: true),
                    Patient = table.Column<int>(type: "int", nullable: true),
                    Practical = table.Column<int>(type: "int", nullable: true),
                    Private = table.Column<int>(type: "int", nullable: true),
                    Shy = table.Column<int>(type: "int", nullable: true),
                    Social = table.Column<int>(type: "int", nullable: true),
                    ShareAboutYourself = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescribeTypicalDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortTermGoals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongTermGoals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HobbiesAndActivities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WantSpouseActiveEnergetic = table.Column<int>(type: "int", nullable: true),
                    WantSpouseAdaptable = table.Column<int>(type: "int", nullable: true),
                    WantSpouseSensitive = table.Column<int>(type: "int", nullable: true),
                    WantSpouseFlexible = table.Column<int>(type: "int", nullable: true),
                    WantSpouseLaidBack = table.Column<int>(type: "int", nullable: true),
                    WantSpousePatient = table.Column<int>(type: "int", nullable: true),
                    WantSpousePractical = table.Column<int>(type: "int", nullable: true),
                    WantSpousePrivate = table.Column<int>(type: "int", nullable: true),
                    WantSpouseShy = table.Column<int>(type: "int", nullable: true),
                    WantSpouseSocial = table.Column<int>(type: "int", nullable: true),
                    MinimumSpouseAge = table.Column<int>(type: "int", nullable: true),
                    MaximumSpouseAge = table.Column<int>(type: "int", nullable: true),
                    ConsiderSpouseWithChildren = table.Column<int>(type: "int", nullable: false),
                    LookingForInSpouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoYouHaveAWali = table.Column<int>(type: "int", nullable: true),
                    WaliName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaliRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaliPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaliEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HaveHealthIssues = table.Column<bool>(type: "bit", nullable: true),
                    HealthIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalImpediments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiveWithFamilyPostMarriage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinancesHandlingAfterMarriage = table.Column<int>(type: "int", nullable: true),
                    WifeContributeFinancially = table.Column<bool>(type: "bit", nullable: true),
                    HusbandSoleProvider = table.Column<bool>(type: "bit", nullable: true),
                    WantToWorkAfterMarriage = table.Column<int>(type: "int", nullable: true),
                    WantWifeToWorkAfterMarriage = table.Column<int>(type: "int", nullable: true),
                    HasDebts = table.Column<bool>(type: "bit", nullable: true),
                    BestWayToContact = table.Column<int>(type: "int", nullable: true),
                    ShareInfoWithMatches = table.Column<bool>(type: "bit", nullable: true),
                    HasDomesticViolenceHistory = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("LanguageId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Language_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "SpouseMaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SpouseMaritalStatusId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpouseMaritalStatus_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StripeCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    RoleClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.RoleClaimId);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    UserClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.UserClaimId);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Language_ProfileId",
                table: "Language",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SpouseMaritalStatus_ProfileId",
                table: "SpouseMaritalStatus",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_ProfileId",
                table: "User",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "SpouseMaritalStatus");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
