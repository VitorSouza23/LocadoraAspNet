using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Queries
{
    /// <summary>
    /// Consulta o filme pelo ID
    /// </summary>
    public class GetMovieByIdQuery : IRequest<(Exception, Movie)>
    {
        /// <summary>
        /// ID do filme
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class GetMovieByIdQueryValidator : AbstractValidator<GetMovieByIdQuery>
    {
        public GetMovieByIdQueryValidator()
        {
            RuleFor(m => m.Id).GreaterThan(0).NotEmpty();
        }
    }
}