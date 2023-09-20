﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacredBond.Core.Contexts;

#nullable disable

namespace SacredBond.Core.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230712114946_AlterProfileAddUniqueIdField")]
    partial class AlterProfileAddUniqueIdField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleClaimId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserClaimId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("SacredBond.Core.Domain.AdminProfile", b =>
                {
                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("ActiveEnergetic")
                        .HasColumnType("int");

                    b.Property<int?>("Adaptable")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BestWayToContact")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConsiderSpouseWithChildren")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescribeTypicalDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoYouHaveAWali")
                        .HasColumnType("int");

                    b.Property<bool?>("DoYouPray5Times")
                        .HasColumnType("bit");

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Ethnicity")
                        .HasColumnType("int");

                    b.Property<int?>("FinancesHandlingAfterMarriage")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Flexible")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasBeard")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasChildren")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasDebts")
                        .HasColumnType("bit");

                    b.Property<int?>("HasDomesticViolenceHistory")
                        .HasColumnType("int");

                    b.Property<bool?>("HaveHealthIssues")
                        .HasColumnType("bit");

                    b.Property<string>("HealthIssues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbiesAndActivities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HusbandSoleProvider")
                        .HasColumnType("bit");

                    b.Property<int?>("LaidBack")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LegalStatus")
                        .HasColumnType("int");

                    b.Property<string>("LiveWithFamilyPostMarriage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongTermGoals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LookingForInSpouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<int?>("MaximumSpouseAge")
                        .HasColumnType("int");

                    b.Property<int?>("MinimumSpouseAge")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Patient")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhysicalImpediments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Practical")
                        .HasColumnType("int");

                    b.Property<int?>("PreferredLanguage")
                        .HasColumnType("int");

                    b.Property<int?>("Private")
                        .HasColumnType("int");

                    b.Property<string>("ReligionImportance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sensitive")
                        .HasColumnType("int");

                    b.Property<string>("ShareAboutYourself")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ShareInfoWithMatches")
                        .HasColumnType("bit");

                    b.Property<string>("ShortTermGoals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Shy")
                        .HasColumnType("int");

                    b.Property<int?>("Social")
                        .HasColumnType("int");

                    b.Property<int?>("SpouseMaritalStatusesId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WaliEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliRelationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WantSpouseActiveEnergetic")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseAdaptable")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseFlexible")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseLaidBack")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePatient")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePractical")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePrivate")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseSensitive")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseShy")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseSocial")
                        .HasColumnType("int");

                    b.Property<int?>("WantToWorkAfterMarriage")
                        .HasColumnType("int");

                    b.Property<int?>("WantWifeToWorkAfterMarriage")
                        .HasColumnType("int");

                    b.Property<int?>("WearsHijab")
                        .HasColumnType("int");

                    b.Property<bool?>("WifeContributeFinancially")
                        .HasColumnType("bit");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("languages")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToView("AdminProfile");
                });

            modelBuilder.Entity("SacredBond.Core.Domain.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("LanguageId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Language", (string)null);
                });

            modelBuilder.Entity("SacredBond.Core.Domain.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProfileId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"), 1L, 1);

                    b.Property<int?>("ActiveEnergetic")
                        .HasColumnType("int");

                    b.Property<int?>("Adaptable")
                        .HasColumnType("int");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BestWayToContact")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConsiderSpouseWithChildren")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescribeTypicalDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoYouHaveAWali")
                        .HasColumnType("int");

                    b.Property<bool?>("DoYouPray5Times")
                        .HasColumnType("bit");

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<int?>("Ethnicity")
                        .HasColumnType("int");

                    b.Property<int?>("FinancesHandlingAfterMarriage")
                        .HasColumnType("int");

                    b.Property<int?>("Flexible")
                        .HasColumnType("int");

                    b.Property<bool?>("HasBeard")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasChildren")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasDebts")
                        .HasColumnType("bit");

                    b.Property<int?>("HasDomesticViolenceHistory")
                        .HasColumnType("int");

                    b.Property<bool?>("HaveHealthIssues")
                        .HasColumnType("bit");

                    b.Property<string>("HealthIssues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HobbiesAndActivities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HusbandSoleProvider")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAboutCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsContactCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEducationalProfessionalCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFamilyCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinanceCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHealthCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMaritalCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPersonalCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReligionCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpouseCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LaidBack")
                        .HasColumnType("int");

                    b.Property<int?>("LegalStatus")
                        .HasColumnType("int");

                    b.Property<string>("LiveWithFamilyPostMarriage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongTermGoals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LookingForInSpouse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<int?>("MaximumSpouseAge")
                        .HasColumnType("int");

                    b.Property<int?>("MinimumSpouseAge")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfChildren")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Patient")
                        .HasColumnType("int");

                    b.Property<string>("PhysicalImpediments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Practical")
                        .HasColumnType("int");

                    b.Property<int?>("PreferredLanguage")
                        .HasColumnType("int");

                    b.Property<int?>("Private")
                        .HasColumnType("int");

                    b.Property<Guid>("ProfileUId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RejectedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReligionImportance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sensitive")
                        .HasColumnType("int");

                    b.Property<string>("ShareAboutYourself")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ShareInfoWithMatches")
                        .HasColumnType("bit");

                    b.Property<string>("ShortTermGoals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Shy")
                        .HasColumnType("int");

                    b.Property<int?>("Social")
                        .HasColumnType("int");

                    b.Property<int?>("SpouseMaritalStatusesId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SubmittedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("WaliEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WaliRelationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WantSpouseActiveEnergetic")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseAdaptable")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseFlexible")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseLaidBack")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePatient")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePractical")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpousePrivate")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseSensitive")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseShy")
                        .HasColumnType("int");

                    b.Property<int?>("WantSpouseSocial")
                        .HasColumnType("int");

                    b.Property<int?>("WantToWorkAfterMarriage")
                        .HasColumnType("int");

                    b.Property<int?>("WantWifeToWorkAfterMarriage")
                        .HasColumnType("int");

                    b.Property<int?>("WearsHijab")
                        .HasColumnType("int");

                    b.Property<bool?>("WifeContributeFinancially")
                        .HasColumnType("bit");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("SacredBond.Core.Domain.ProfileLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("ProfileLanguageId");

                    b.ToTable("ProfileLanguage", (string)null);
                });

            modelBuilder.Entity("SacredBond.Core.Domain.ProfileMatches", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MatchId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchId"), 1L, 1);

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CanceledDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RejectedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SpouseId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("StatusChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MatchId")
                        .HasName("MatchId");

                    b.ToTable("ProfileMatches", (string)null);
                });

            modelBuilder.Entity("SacredBond.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StripeCustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfileId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SacredBond.Core.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SacredBond.Core.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacredBond.Core.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SacredBond.Core.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SacredBond.Core.Domain.Language", b =>
                {
                    b.HasOne("SacredBond.Core.Domain.Profile", null)
                        .WithMany("PrimaryLanguages")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("SacredBond.Core.Domain.User", b =>
                {
                    b.HasOne("SacredBond.Core.Domain.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SacredBond.Core.Domain.Profile", b =>
                {
                    b.Navigation("PrimaryLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
