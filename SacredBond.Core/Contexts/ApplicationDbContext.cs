using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> User { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<ProfileLanguage> ProfileLanguage { get; set; }
        public DbSet<ProfileMatches> ProfileMatches { get; set; }
        public DbSet<ProfileStatusChange> ProfileStatusChanges { get; set; }
        public DbSet<ProfileMatchStatusChange> ProfileMatchStatusChanges { get; set; }
        //public string ConnectionString { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Identity Changes.
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("UserId").IsRequired();

            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Role");
            modelBuilder.Entity<IdentityRole<Guid>>().Property(p => p.Id).HasColumnName("RoleId").IsRequired();

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().Property(p => p.Id).HasColumnName("RoleClaimId");

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogin");

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().Property(p => p.Id).HasColumnName("UserClaimId");

            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");


            modelBuilder.Entity<Profile>().ToTable("Profile");
            modelBuilder.Entity<Profile>().Property(p => p.ProfileId).HasColumnName("ProfileId").IsRequired();

            modelBuilder.Entity<Language>().ToTable("Language");
            modelBuilder.Entity<Language>().Property(p => p.Id).HasColumnName("Id").IsRequired();

            modelBuilder.Entity<ProfileLanguage>().ToTable("ProfileLanguage");
            modelBuilder.Entity<ProfileLanguage>().Property(p => p.Id).HasColumnName("Id").IsRequired();

            modelBuilder.Entity<ProfileMatches>().ToTable("ProfileMatches");
            modelBuilder.Entity<ProfileMatches>().Property(p => p.MatchId).HasColumnName("MatchId").IsRequired();

            modelBuilder.Entity<ProfileStatusChange>().ToTable("ProfileStatusChange");
            modelBuilder.Entity<ProfileStatusChange>().Property(p => p.Id).HasColumnName("Id").IsRequired();

            modelBuilder.Entity<ProfileMatchStatusChange>().ToTable("ProfileMatchStatusChange");
            modelBuilder.Entity<ProfileMatchStatusChange>().Property(p => p.Id).HasColumnName("Id").IsRequired();

        }

    }
}