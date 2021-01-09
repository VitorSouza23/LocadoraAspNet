using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    public class PutGenreCommand : IRequest<(Exception, Genre)>
    {
        /// <summary>
        /// ID do gênero
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Novo nome do gênero
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Novo status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }
    }

    public class PutGenreCommandValidator : AbstractValidator<PutGenreCommand>
    {
        public PutGenreCommandValidator()
        {
            RuleFor(g => g.Id).GreaterThan(0).NotEmpty();
            RuleFor(g => g.Name).NotEmpty();
            RuleFor(g => g.Active).NotNull();
        }
    }
}