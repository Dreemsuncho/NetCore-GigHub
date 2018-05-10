using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    internal class ConfigFollowing : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.HasKey(f => new { f.FollowerId, f.FolloweeId });
            builder.HasOne(f => f.Follower).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.Follower).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
