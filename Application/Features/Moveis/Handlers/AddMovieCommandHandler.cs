using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Movies.Commands;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Handlers
{
    public class AddMovieCommandHandler : IRequestHandler<AddMovieCommand, (Exception, Movie)>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public AddMovieCommandHandler(IMovieRepository movieRepository, IGenreRepository genreRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<(Exception, Movie)> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            (Exception ex, Genre genre) = await _genreRepository.GetByIdAsync(request.GenreId);
            if (ex != null)
                return (ex, null);

            var movie = _mapper.Map<AddMovieCommand, Movie>(request);
            movie.Genre = genre;

            if (!movie.GenreIsActived())
                return (new NotActivedException($"O gênero de ID {genre.Id} não está ativo."), null);

            return await _movieRepository.AddAsync(movie);
        }
    }
}