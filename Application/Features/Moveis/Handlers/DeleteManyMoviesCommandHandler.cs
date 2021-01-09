using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Moveis.Commands;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Moveis.Handlers
{
    public class DeleteManyMoviesCommandHandler : IRequestHandler<DeleteManyMoviesCommand, (Exception, IEnumerable<Movie>)>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteManyMoviesCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<(Exception, IEnumerable<Movie>)> Handle(DeleteManyMoviesCommand request, CancellationToken cancellationToken)
        {
            return await _movieRepository.DeleteManyAsync(request.Ids);
        }
    }
}