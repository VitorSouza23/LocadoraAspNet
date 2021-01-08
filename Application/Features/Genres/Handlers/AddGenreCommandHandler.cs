using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Handlers
{
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommand, (Exception, Genre)>
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public AddGenreCommandHandler(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<(Exception, Genre)> Handle(AddGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<AddGenreCommand, Genre>(request);
            return await _genreRepository.AddAsync(genre);
        }
    }
}