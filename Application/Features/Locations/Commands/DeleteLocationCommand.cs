using System;
using FluentValidation;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Commands
{
    /// <summary>
    /// Comando de exclusão da locação
    /// </summary>
    public class DeleteLocationCommand : IRequest<(Exception, Location)>
    {
        /// <summary>
        /// ID da locação
        /// </summary>
        /// <value></value>
        public int Id { get; set; }
    }

    public class DeleteLocationCommandValidator : AbstractValidator<DeleteLocationCommand>
    {
        public DeleteLocationCommandValidator()
        {
            RuleFor(d => d.Id).GreaterThan(0).NotEmpty();
        }
    }
}