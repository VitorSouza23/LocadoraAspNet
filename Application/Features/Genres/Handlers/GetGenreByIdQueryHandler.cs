using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LocadoraAspNet.Application.Features.Genres.Queries;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Handlers
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, (Exception, Genre)>
    {
        private readonly IGenreRepository _genreRepository;

        public GetGenreByIdQueryHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<(Exception, Genre)> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetGenreByIdQueryValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _genreRepository.GetByIdAsync(request.Id);
        }
    }
}