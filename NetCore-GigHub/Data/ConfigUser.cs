using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    internal class ConfigUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.UserName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(40)
                .IsRequired();

            builder.ToTable("Users");
        }
    }
}
