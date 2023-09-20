using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Contexts.ClassMaps
{
    internal class AdminProfileMapping : IEntityTypeConfiguration<AdminProfile>
    {
        public void Configure(EntityTypeBuilder<AdminProfile> builder)
        {
            builder.ToView("AdminProfile");
            builder.HasKey(x => x.ProfileId);
        }
    }
}
