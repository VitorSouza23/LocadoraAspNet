using LocadoraAspNet.Models.Features.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAspNet.InfraData.Features.Genres
{
    internal class GenreEntityConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(100).IsRequired();
            builder.Property(g => g.CreationDate).IsRequired();
            builder.Property(g => g.Active).IsRequired();

            builder.HasMany(g => g.Movies).WithOne(m => m.Genre);
        }
    }
}