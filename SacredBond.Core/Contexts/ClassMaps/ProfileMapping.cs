using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Contexts.ClassMaps
{
    internal class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            //Key
            builder.HasKey(x => x.ProfileId);
        }
    }
}
