using System;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using LocadoraAspNet.Application.Features.Moveis.Commands;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Moveis.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, (Exception, Movie)>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<(Exception, Movie)> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _movieRepository.DeleteAsync(request.Id);
        }
    }
}