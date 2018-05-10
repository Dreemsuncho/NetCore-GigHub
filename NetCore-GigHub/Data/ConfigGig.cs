using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_GigHub.Entities;

namespace NetCore_GigHub.Data
{
    internal class ConfigGig : IEntityTypeConfiguration<Gig>
    {
        public void Configure(EntityTypeBuilder<Gig> builder)
        {

            builder.Property(g => g.ArtistId)
                .IsRequired();

            builder.Property(g => g.GenreId)
                .IsRequired();

            builder.Property(g => g.Venue)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(g => g.DateTime)
                .IsRequired();
        }
    }
}
