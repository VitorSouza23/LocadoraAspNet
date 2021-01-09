using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Handlers
{
    public class PutGenreCommandHandler : IRequestHandler<PutGenreCommand, (Exception, Genre)>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public PutGenreCommandHandler(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<(Exception, Genre)> Handle(PutGenreCommand request, CancellationToken cancellationToken)
        {
            (Exception exception, Genre currentGnere) = await _genreRepository.GetByIdAsync(request.Id);
            if (exception != null)
                return (exception, null);
            _mapper.Map<PutGenreCommand, Genre>(request, currentGnere);
            return await _genreRepository.UpdateAsync(currentGnere);
        }
    }
}