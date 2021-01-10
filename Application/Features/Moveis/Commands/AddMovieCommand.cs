using System;
using System.Data;
using FluentValidation;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Commands
{
    /// <summary>
    /// Comando de adição de filme
    /// </summary>
    public class AddMovieCommand : IRequest<(Exception, Movie)>
    {
        /// <summary>
        /// Nome do filme
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }

        /// <summary>
        /// ID do genero de filme
        /// </summary>
        /// <value></value>
        public int GenreId { get; set; }
    }

    public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
    {
        public AddMovieCommandValidator()
        {
            RuleFor(a => a.Name).MaximumLength(200).NotEmpty();
            RuleFor(a => a.Active).NotNull();
            RuleFor(a => a.GenreId).NotEmpty();
        }
    }
}