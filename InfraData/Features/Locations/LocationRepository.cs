using LocadoraAspNet.InfraData.Base;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Locations;

namespace LocadoraAspNet.InfraData.Features.Locations
{
    public class LocationRespository : AbstractRepository<Location>, ILocationRepository
    {
        public LocationRespository(DataContext context) : base(context)
        {
        }
    }
}