using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LocadoraAspNet.Application.Features.Movies.Queries;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Handlers
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, (Exception, IEnumerable<Movie>)>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<(Exception, IEnumerable<Movie>)> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.GetAllAsync();
        }
    }
}