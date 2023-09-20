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
    internal class ProfileMatcheMapping : IEntityTypeConfiguration<ProfileMatches>
    {
        public void Configure(EntityTypeBuilder<ProfileMatches> builder)
        {
            builder.HasKey(pm => pm.MatchId).HasName("MatchId");
        }
    }
}
