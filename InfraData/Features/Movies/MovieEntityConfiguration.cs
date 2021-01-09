using LocadoraAspNet.Models.Features.Movies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAspNet.InfraData.Features.Movies
{
    internal class MovieEntityConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).HasMaxLength(200).IsRequired();
            builder.Property(m => m.CreationDate).IsRequired();
            builder.Property(m => m.Active).IsRequired();

            builder.Property(m => m.GenreId).IsRequired();
            builder.HasOne(m => m.Genre).WithMany(g => g.Movies);

            builder.HasOne(m => m.Location)
                .WithMany(l => l.Movies)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}