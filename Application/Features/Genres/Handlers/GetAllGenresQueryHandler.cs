using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LocadoraAspNet.Application.Features.Genres.Queries;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Handlers
{
    public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, (Exception, IEnumerable<Genre>)>
    {
        private readonly IGenreRepository _genreRepository;

        public GetAllGenresQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<(Exception, IEnumerable<Genre>)> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return await _genreRepository.GetAllAsync();
        }
    }
}