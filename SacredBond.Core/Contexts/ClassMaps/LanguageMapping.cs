using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SacredBond.Core.Domain;

namespace SacredBond.Core.Contexts.ClassMaps
{
    internal class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id).HasName("LanguageId");
        }
    }
}
