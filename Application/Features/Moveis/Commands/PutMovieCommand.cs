using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Commands
{
    /// <summary>
    /// Comando de alteração de filme
    /// </summary>
    public class PutMovieCommand : IRequest<(Exception, Movie)>
    {
        /// <summary>
        /// Id do filme
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Novo nome do filme
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Novo status de ativação do filme
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }

        /// <summary>
        /// Novo ID de gênero de filme
        /// </summary>
        /// <value></value>
        public int GenreId { get; set; }
    }

    public class PutMovieCommandValidator : AbstractValidator<PutMovieCommand>
    {
        public PutMovieCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).NotEmpty();
            RuleFor(p => p.Name).MaximumLength(200).NotEmpty();
            RuleFor(p => p.Active).NotNull();
            RuleFor(p => p.GenreId).NotEmpty();
        }
    }
}