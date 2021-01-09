using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LocadoraAspNet.Application.Features.Locations.Commands;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Handlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, (Exception, Location)>
    {
        private readonly ILocationRepository _locationRepository;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<(Exception, Location)> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteLocationCommandValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _locationRepository.DeleteAsync(request.Id);
        }
    }
}