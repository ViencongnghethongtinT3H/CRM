using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public  class AdministrativeUnitConfiguration
    {
        public void Configure(EntityTypeBuilder<AdministrativeUnit> builder)
        {
            builder.ToTable("administrative_unit");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasColumnName("full_name");
            builder.Property(x => x.EnglishFullName).HasColumnName("english_full_name");
            builder.Property(x => x.ShortName).HasColumnName("short_name");
            builder.Property(x => x.EnglishShortName).HasColumnName("english_short_name");
        }
    }
}
