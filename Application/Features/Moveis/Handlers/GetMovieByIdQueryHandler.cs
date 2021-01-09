using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LocadoraAspNet.Application.Features.Movies.Queries;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, (Exception, Movie)>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<(Exception, Movie)> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMovieByIdQueryValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _movieRepository.GetByIdAsync(request.Id);
        }
    }
}