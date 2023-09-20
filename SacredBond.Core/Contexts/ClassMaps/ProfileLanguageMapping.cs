using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SacredBond.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SacredBond.Core.Contexts.ClassMaps
{
    internal class ProfileLanguageMapping : IEntityTypeConfiguration<ProfileLanguage>
    {
        public void Configure(EntityTypeBuilder<ProfileLanguage> builder)
        {
            builder.HasKey(x => x.Id).HasName("ProfileLanguageId");
        }
    }
}
