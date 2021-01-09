using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Queries
{
    public class GetGenreByIdQuery : IRequest<(Exception, Genre)>
    {
        /// <summary>
        /// ID do gênero a ser buscado
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(g => g.Id).GreaterThan(0).NotEmpty();
        }
    }
}