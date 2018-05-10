using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    internal class ConfigAttendance : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => new { a.GigId, a.UserId });
            builder.HasOne(a => a.Gig).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.User).WithMany().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
