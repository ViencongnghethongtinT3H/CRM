﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FDS.CRM.Persistence.MappingConfigurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");
        builder.Property(x => x.Id).HasDefaultValueSql("newsequentialid()");

        builder.HasMany(x => x.Claims)
            .WithOne(x => x.Role)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.UserRoles)
            .WithOne(x => x.Role)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
