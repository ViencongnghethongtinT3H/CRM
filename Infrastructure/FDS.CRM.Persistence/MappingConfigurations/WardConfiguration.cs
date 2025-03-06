using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public class WardConfiguration : IEntityTypeConfiguration<Ward>
    {
        public void Configure(EntityTypeBuilder<Ward> builder)
        {
            builder.ToTable("ward");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(26);

            builder.Property(x => x.DistrictCode).HasColumnName("district_code");
            builder.Property(x => x.DistrictId).HasColumnName("district_id").HasMaxLength(26);
            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.EnglishName).HasColumnName("english_name");
            builder.Property(x => x.FullName).HasColumnName("full_name");
            builder.Property(x => x.EnglishFullName).HasColumnName("english_full_name");
            builder.Property(x => x.CustomName).HasColumnName("custom_name");
            builder.Property(x => x.AdministrativeUnitId).HasColumnName("administrative_unit_id");

            builder.HasOne(x => x.District)
                .WithMany(x => x.Wards)
                .HasForeignKey(x => x.DistrictId)
                 .OnDelete(DeleteBehavior.NoAction); // Thêm này

            builder.HasOne(x => x.AdministrativeUnit)
                .WithMany(x => x.Wards)
                .HasForeignKey(x => x.AdministrativeUnitId)
                 .OnDelete(DeleteBehavior.NoAction); // Thêm này

        }
    }
}
