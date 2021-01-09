using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LocadoraAspNet.Application.Features.Locations.Queries;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Handlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, (Exception, Location)>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<(Exception, Location)> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetLocationByIdQueryValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _locationRepository.GetByIdAsync(request.Id);
        }
    }
}