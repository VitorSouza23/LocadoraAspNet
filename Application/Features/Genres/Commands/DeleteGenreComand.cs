using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Commands
{
    public class DeleteGenreComand : IRequest<(Exception, Genre)>
    {
        public int Id { get; set; }
    }

    public class DeleteGenreComandValidator : AbstractValidator<DeleteGenreComand>
    {
        public DeleteGenreComandValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0).NotEmpty();
        }
    }
}