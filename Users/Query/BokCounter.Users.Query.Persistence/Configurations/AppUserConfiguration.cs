using BokCounter.Users.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BokCounter.Users.Query.Persistence.Configurations;

public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                (id) => id.Value,
                (value) => new AppUserId(value));

        builder.Property(x => x.AppIdentityUserId)
            .HasConversion(
                (id) => id.Value,
                (value) => new AppIdentityUserId(value));
    }
}
