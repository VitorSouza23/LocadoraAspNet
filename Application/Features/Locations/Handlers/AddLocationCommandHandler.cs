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
    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, (Exception, Location)>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public AddLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper, IMovieRepository movieRepository)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<(Exception, Location)> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            (Exception ex, IEnumerable<Movie> movies) = await _movieRepository.GetManyAsync(request.MoviesIds.ToArray());

            if (ex != null)
                return (ex, null);

            if (!movies.All(m => m.Active))
                return (new NotFoundException("Nem todos os filmes solicitados existem na base"), null);

            var location = _mapper.Map<AddLocationCommand, Location>(request);
            location.SetMovies(movies);
            return await _locationRepository.AddAsync(location);
        }
    }
}