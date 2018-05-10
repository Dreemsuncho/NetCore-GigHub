using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    internal class ConfigClaimUser : IEntityTypeConfiguration<ClaimUser>
    {
        public void Configure(EntityTypeBuilder<ClaimUser> builder)
        {
            builder.Property(c => c.UserId)
                .IsRequired();

            builder.Property(c => c.ClaimType)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(c => c.ClaimValue)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
