using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Moveis.Commands
{
    /// <summary>
    /// Comando de exclusão de filme
    /// </summary>
    public class DeleteMovieCommand : IRequest<(Exception, Movie)>
    {
        /// <summary>
        /// ID do filme
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0).NotEmpty();
        }
    }
}