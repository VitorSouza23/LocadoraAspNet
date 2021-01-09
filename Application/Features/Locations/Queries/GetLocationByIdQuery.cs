using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Queries
{
    /// <summary>
    /// Consulta a locação por ID
    /// </summary>
    public class GetLocationByIdQuery : IRequest<(Exception, Location)>
    {
        /// <summary>
        /// ID da locação
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class GetLocationByIdQueryValidator : AbstractValidator<GetLocationByIdQuery>
    {
        public GetLocationByIdQueryValidator()
        {
            RuleFor(q => q.Id).GreaterThan(0).NotEmpty();
        }
    }
}