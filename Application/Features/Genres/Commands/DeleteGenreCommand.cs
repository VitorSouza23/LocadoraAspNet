using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    /// <summary>
    /// Comando de exclusão de gênero de filmes
    /// </summary>
    public class DeleteGenreCommand : IRequest<(Exception, Genre)>
    {
        /// <summary>
        /// ID do gênero
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class DeleteGenreComandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreComandValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0).NotEmpty();
        }
    }
}