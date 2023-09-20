using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SacredBond.Common.Enums;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using Domain = SacredBond.Core.Domain;

namespace SacredBondFaker
{
    class Program
    {
        private static string PASSWORD = "Welcome8890!";
        private static int NUMBER_OF_USERS = 1000;
        private static ApplicationDbContext Context;
        private static UserManager<User> UserManager;
        private static RoleManager<IdentityRole<Guid>> RoleManager;
        private static IMapper Mapper;

        public static async Task Main(string[] args)
        {
            var config = Setup.GetConfiguration();
            var serviceProvider = Setup.Build(config);

            Context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            Console.WriteLine("Here we start");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Profile, Domain.Profile>()
                    .ForMember(x => x.ProfileId, opt => opt.Ignore()); ;
            });
            Mapper = configuration.CreateMapper();
            //Add all the admin users
            await Program.AddAdminUsers();
            List<User> fakeUsers = DataSeeder.SeedUsers(NUMBER_OF_USERS);
            List<Domain.Profile> fakeProfiles = DataSeeder.SeedProfiles(NUMBER_OF_USERS);
            for (int i = 0; i < fakeUsers.Count; i++)
            {
                var user = fakeUsers[i];
                var profile = fakeProfiles[i];
                profile.ProfileLanguages = new List<ProfileLanguage>
                {
                    new ProfileLanguage()
                    {
                        ProfileId = profile.ProfileId,
                        LanguageId = (int)profile.PreferredLanguage
                    }
                };
                if (RegisterUser(user))
                {
                    SetupAccount(user, profile);
                }
            }
        }

        public static bool RegisterUser(User user)
        {
            user.UserName = user.Email;
            var result = UserManager.CreateAsync(user, PASSWORD).Result;
            if (result.Succeeded)
                Console.WriteLine($"User {user.UserName} registered successfully!");
            else
            {
                var errors = result.Errors.Select(e => e.Description).ToArray();
                Console.WriteLine($"User {user.UserName} registration failed!. {string.Join(",", errors)}");
            }
            return result.Succeeded;
        }


        private static void SetupAccount(User user, Domain.Profile profile)
        {
            var userAccount = Context.User.Find(user.Id);
            if (userAccount != null)
            {
                userAccount.EmailConfirmed = true;
                userAccount.PhoneNumberConfirmed = true;
                Mapper.Map(profile, userAccount.Profile);

                Context.Update(userAccount);
                Context.Update(userAccount.Profile);

                Context.SaveChanges();
            }
        }
        private static async Task AddAdminUsers()
        {
            Console.WriteLine("Entered the AddAdminUsers function");

            var userManager = UserManager;

            // Check if the "Admin" role exists, and create it if it doesn't
            var roleExists = await RoleManager.RoleExistsAsync("Admin");
            if (!roleExists)
            {
                var role = new IdentityRole<Guid>("Admin");
                await RoleManager.CreateAsync(role);

                var user1 = new User
                {
                    FirstName = "Sajeela",
                    LastName = "Yaqub",
                    UserName = "syaqub@darussalaam.org",
                    Email = "syaqub@darussalaam.org",
                    PhoneNumber = "123456789",
                    Gender = Genders.Female
                };
                var user2 = new User
                {
                    FirstName = "Helen",
                    LastName = "",
                    UserName = "helenm@darussalaam.org",
                    Email = "helenm@darussalaam.org",
                    PhoneNumber = "123456789",
                    Gender = Genders.Female,
                };
                var user3 = new User
                {
                    FirstName = "Sami",
                    LastName = "Hijazi",
                    UserName = "sami.hijazi@88ninety.com",
                    Email = "sami.hijazi@88ninety.com",
                    PhoneNumber = "123456789",
                    Gender = Genders.Male
                };
                user1.EmailConfirmed = true;
                user2.EmailConfirmed = true;
                user3.EmailConfirmed = true;



                var result1 = await userManager.CreateAsync(user1, PASSWORD);
                var result2 = await userManager.CreateAsync(user2, PASSWORD);
                var result3 = await userManager.CreateAsync(user3, PASSWORD);

                if (result1.Succeeded && result2.Succeeded && result3.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "Admin");
                    await userManager.AddToRoleAsync(user2, "Admin");
                    await userManager.AddToRoleAsync(user3, "Admin");

                    Console.WriteLine("Adding users as admins was successful");
                }
                else
                {
                    var errors1 = string.Join(", ", result1.Errors.Select(e => e.Description));
                    var errors2 = string.Join(", ", result2.Errors.Select(e => e.Description));
                    var errors3 = string.Join(", ", result3.Errors.Select(e => e.Description));
                    Console.WriteLine($"Failed to add users as admins. Errors: {errors1}, {errors2}, {errors3}");
                }
            }
            else
            {
                Console.WriteLine("Admin Users are already in the database");
            }

        }

    }
}
