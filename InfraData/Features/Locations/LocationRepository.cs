using System;
using System.Linq;
using System.Threading.Tasks;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.InfraData.Base;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Locations;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.InfraData.Features.Locations
{
    public class LocationRespository : AbstractRepository<Location>, ILocationRepository
    {
        public LocationRespository(DataContext context) : base(context)
        {

        }

        protected override IQueryable<Location> FindByIdCustomQuery() => _context.Locations
                .Include(l => l.Movies)
                .ThenInclude(m => m.Genre)
                .AsQueryable();
        protected override IQueryable<Location> FindAllCustomQuery() => _context.Locations
                .Include(l => l.Movies)
                .ThenInclude(m => m.Genre)
                .AsQueryable();

        public override async Task<(Exception, Location)> DeleteAsync(int id)
        {
            Location deletedLocation;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                deletedLocation = await _context.Locations
                    .Include(l => l.Movies)
                    .ThenInclude(m => m.Genre)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (deletedLocation == null)
                {
                    await transaction.RollbackAsync();
                    return (new NotFoundException(), null);
                }

                _context.Locations.Remove(deletedLocation);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, deletedLocation);
        }
    }
}