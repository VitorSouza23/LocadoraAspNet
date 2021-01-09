using System;
using System.Collections.Generic;
using FluentValidation;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace Application.Features.Moveis.Commands
{
    /// <summary>
    /// Comando para exclusão para mais de um filme
    /// </summary>
    public class DeleteManyMoviesCommand : IRequest<(Exception, IEnumerable<Movie>)>
    {
        /// <summary>
        /// ID dos filmes que serão excluídos
        /// </summary>
        /// <value></value>
        public IEnumerable<int> Ids { get; set; }
    }

    public class DeleteMoviesCommandValidator : AbstractValidator<DeleteManyMoviesCommand>
    {
        public DeleteMoviesCommandValidator()
        {
            RuleFor(d => d.Ids).NotEmpty();
        }
    }
}