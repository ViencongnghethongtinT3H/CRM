using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("province");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasMaxLength(26);

            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.EnglishName).HasColumnName("english_name");
            builder.Property(x => x.FullName).HasColumnName("full_name");
            builder.Property(x => x.EnglishFullName).HasColumnName("english_full_name");
            builder.Property(x => x.CustomName).HasColumnName("custom_name");
            builder.Property(x => x.AdministrativeUnitId).HasColumnName("administrative_unit_id");

            builder.HasOne(x => x.AdministrativeUnit)
                .WithMany(x => x.Provinces)
                .HasForeignKey(x => x.AdministrativeUnitId)
                 .OnDelete(DeleteBehavior.NoAction); // Thêm này
        }
    }
}
