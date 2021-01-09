using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Movies.Commands;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Moveis.Handlers
{
    public class PutMovieCommandHandler : IRequestHandler<PutMovieCommand, (Exception, Movie)>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public PutMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<(Exception, Movie)> Handle(PutMovieCommand request, CancellationToken cancellationToken)
        {
            (Exception ex, Genre genre) = await _genreRepository.GetByIdAsync(request.GenreId);
            if (ex != null)
                return (ex, null);

            (Exception exc, Movie movie) = await _movieRepository.GetByIdAsync(request.Id);
            if (exc != null)
                return (exc, null);

            _mapper.Map<PutMovieCommand, Movie>(request, movie);
            movie.Genre = genre;

            if (!movie.GenreIsActived())
                return (new NotActivedException($"O gênero de ID {genre.Id} não está ativo."), null);

            return await _movieRepository.UpdateAsync(movie);
        }
    }
}