using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Locations.Commands;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Locations;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Handlers
{
    public class PutLocationCommandHandler : IRequestHandler<PutLocationCommand, (Exception, Location)>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public PutLocationCommandHandler(ILocationRepository locationRepository, IMovieRepository movieRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<(Exception, Location)> Handle(PutLocationCommand request, CancellationToken cancellationToken)
        {
            (Exception ex, IEnumerable<Movie> movies) = await _movieRepository.GetManyAsync(request.MoviesIds.ToArray());

            if (ex != null)
                return (ex, null);

            if (!movies.All(m => m.Active))
                return (new NotFoundException("Nem todos os filmes solicitados existem na base"), null);

            (Exception exc, Location location) = await _locationRepository.GetByIdAsync(request.Id);
            if (exc != null)
                return (exc, null);

            _mapper.Map<PutLocationCommand, Location>(request, location);
            location.SetMovies(movies);
            return await _locationRepository.UpdateAsync(location);
        }
    }
}