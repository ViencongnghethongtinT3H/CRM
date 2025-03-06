using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> builder)
        {
            builder.ToTable("Deals");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
