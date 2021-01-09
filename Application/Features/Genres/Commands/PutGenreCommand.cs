using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    public class PutGenreCommand : IRequest<(Exception, Genre)>
    {
        public int Id { get; set; }
        public string Name { get; set; }
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