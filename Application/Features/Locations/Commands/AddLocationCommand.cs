using System;
using System.Collections.Generic;
using FluentValidation;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Commands
{
    /// <summary>
    /// Comando de adição de locação
    /// </summary>
    public class AddLocationCommand : IRequest<(Exception, Location)>
    {
        /// <summary>
        /// IDs dos filmes
        /// </summary>
        /// <value></value>
        public virtual IEnumerable<int> MoviesIds { get; set; }

        /// <summary>
        /// CPF do cliente
        /// </summary>
        /// <value></value>
        public virtual string CustomerCpf { get; set; }
    }

    public class AddLocationCommandValidator : AbstractValidator<AddLocationCommand>
    {
        public AddLocationCommandValidator()
        {
            RuleFor(a => a.MoviesIds).NotEmpty();
            RuleFor(a => a.CustomerCpf).NotEmpty().Must(a => Cpf.IsValid(a)).WithMessage("CPF inválido");
        }
    }
}