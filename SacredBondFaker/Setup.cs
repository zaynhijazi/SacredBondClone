using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SacredBond.Core.Contexts;
using SacredBond.Core.Domain;
using Stripe;

namespace SacredBondFaker
{
    public static class Setup
    {
        public static ServiceProvider Build(IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];

            // Create a service collection
            var services = new ServiceCollection();

            // Configure Identity services
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)); // Register your ApplicationDbContext

            // Replace the existing RoleManager registration
            services.AddIdentity<User, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders()
                    .AddRoles<IdentityRole<Guid>>();



            services.AddScoped<RoleManager<IdentityRole>>(); // Remove the <Guid> type argument

            // Register the data protection services
            services.AddDataProtection();

            services.AddLogging();

            // Build the service provider. And now you can get the dbContext.
            return services.BuildServiceProvider();
        }

        internal static IConfiguration GetConfiguration()
        {
            var x = Directory.GetCurrentDirectory().Split("bin");

            return new ConfigurationBuilder()
                .SetBasePath(x[0])
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
