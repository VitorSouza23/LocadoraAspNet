using LocadoraAspNet.Models.Features.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAspNet.InfraData.Features.Locations
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LocationDate).IsRequired();
            builder.Property(l => l.CustomerCpf)
                .HasMaxLength(14)
                .IsRequired()
                .HasConversion(c => c.Value, c => new Cpf(c));

            builder.HasMany(l => l.Movies)
                .WithOne(m => m.Location)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}