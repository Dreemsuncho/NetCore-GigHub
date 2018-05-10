using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{

    public class ContextGigHub : IdentityDbContext<User, RoleUser, int>
    {
        public ContextGigHub(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ClaimUser> Claims { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ConfigGig());
            builder.ApplyConfiguration(new ConfigGenre());
            builder.ApplyConfiguration(new ConfigUser());
            builder.ApplyConfiguration(new ConfigClaimUser());
            builder.ApplyConfiguration(new ConfigAttendance());
            builder.ApplyConfiguration(new ConfigFollowing());
        }
    }
}
