using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDS.CRM.Persistence.MappingConfigurations
{
    public class QuoreConfiguration : IEntityTypeConfiguration<Quotes>
    {
        public void Configure(EntityTypeBuilder<Quotes> builder)
        {
            builder.ToTable("Quotes");
            builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");
        }
    }
}
