using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    public class ContextGigHub : IdentityDbContext<User, UserRole, int>
    {
        public ContextGigHub(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>(options =>
            {
                options.Property(u => u.UserName)
                .HasMaxLength(40)
                .IsRequired();

                options.Property(u => u.Email)
                .HasMaxLength(40)
                .IsRequired();
            });
        }
    }
}
