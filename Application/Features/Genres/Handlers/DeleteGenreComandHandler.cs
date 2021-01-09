using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Handlers
{
    public class DeleteGenreComandHandler : IRequestHandler<DeleteGenreCommand, (Exception, Genre)>
    {
        private readonly IGenreRepository _genreRepository;

        public DeleteGenreComandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<(Exception, Genre)> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteGenreComandValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
                return (new ValidationException(result.Errors), null);

            return await _genreRepository.DeleteAsync(request.Id);
        }
    }
}