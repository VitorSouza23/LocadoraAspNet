using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    /// <summary>
    /// Comando para adição de gênero de filmes
    /// </summary>
    public class AddGenreCommand : IRequest<(Exception, Genre)>
    {
        /// <summary>
        /// Nome do gênero
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }
    }

    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            RuleFor(g => g.Name).MaximumLength(100).NotEmpty();
            RuleFor(g => g.Active).NotNull();
        }
    }
}