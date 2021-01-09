using System.Linq;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Locations;
using LocadoraAspNet.Models.Features.Movies;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.InfraData.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            ApplyMigrations();
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

        private void ApplyMigrations()
        {
            var pendingMigrations = Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                Database.Migrate();
            }
        }
    }
}