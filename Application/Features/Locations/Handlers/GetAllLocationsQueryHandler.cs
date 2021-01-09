using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LocadoraAspNet.Application.Features.Locations.Queries;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Handlers
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, (Exception, IEnumerable<Location>)>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllLocationsQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<(Exception, IEnumerable<Location>)> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _locationRepository.GetAllAsync();
        }
    }
}