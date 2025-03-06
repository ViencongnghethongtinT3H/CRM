using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("district");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(26);

            builder.Property(x => x.ProvinceCode).HasColumnName("province_code");
            builder.Property(x => x.ProvinceId).HasColumnName("province_id").HasMaxLength(26);
            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.EnglishName).HasColumnName("english_name");
            builder.Property(x => x.FullName).HasColumnName("full_name");
            builder.Property(x => x.EnglishFullName).HasColumnName("english_full_name");
            builder.Property(x => x.CustomName).HasColumnName("custom_name");
            builder.Property(x => x.AdministrativeUnitId).HasColumnName("administrative_unit_id");

            builder.HasOne(x => x.Province)
                .WithMany(x => x.Districts)
                .HasForeignKey(x => x.ProvinceId)
                 .OnDelete(DeleteBehavior.NoAction); // Thêm này

            builder.HasOne(x => x.AdministrativeUnit)
                .WithMany(x => x.Districts)
                .HasForeignKey(x => x.AdministrativeUnitId)
             .OnDelete(DeleteBehavior.NoAction); // Thêm này
        }
    }
}
