using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    public class AddGenreCommand : IRequest<(Exception, Genre)>
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }

    public class AddGenreCommandValidator : AbstractValidator<AddGenreCommand>
    {
        public AddGenreCommandValidator()
        {
            RuleFor(g => g.Name).NotEmpty();
            RuleFor(g => g.CreationDate).NotNull();
            RuleFor(g => g.Active).NotNull();
        }
    }
}