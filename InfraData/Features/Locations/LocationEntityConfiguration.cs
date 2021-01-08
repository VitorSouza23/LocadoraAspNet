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

            builder.OwnsOne(l => l.CustomerCpf, c => c.Property(cpf => cpf.Value).IsRequired());
            builder.HasMany(l => l.Movies);
        }
    }
}