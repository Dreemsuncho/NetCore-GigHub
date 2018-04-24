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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>(cfg =>
            {
                cfg.Property(u => u.UserName)
                .HasMaxLength(40)
                .IsRequired();

                cfg.Property(u => u.Email)
                .HasMaxLength(40)
                .IsRequired();
            });

            builder.Entity<Gig>(cfg =>
            {
                cfg.Property(g => g.ArtistId)
                    .IsRequired();

                cfg.Property(g => g.GenreId)
                    .IsRequired();

                cfg.Property(g => g.Venue)
                    .IsRequired()
                    .HasMaxLength(40);

                cfg.Property(g => g.DateTime)
                    .IsRequired();
            });

            builder.Entity<Genre>(cfg =>
            {
                cfg.Property(g => g.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            builder.Entity<ClaimUser>(cfg =>
            {
                cfg.Property(c => c.UserId)
                    .IsRequired();

                cfg.Property(c => c.ClaimType)
                    .IsRequired()
                    .HasMaxLength(40);

                cfg.Property(c => c.ClaimValue)
                    .IsRequired()
                    .HasMaxLength(40);
            });
        }
    }
}
