using System;
using System.Collections.Generic;
using FluentValidation;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Commands
{
    /// <summary>
    /// Comando de atualização dos dados da locação
    /// </summary>
    public class PutLocationCommand : IRequest<(Exception, Location)>
    {
        /// <summary>
        /// ID da locação
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

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

    public class PutLocationCommandValidator : AbstractValidator<PutLocationCommand>
    {
        public PutLocationCommandValidator()
        {
            RuleFor(p => p.Id).GreaterThan(0).NotEmpty();
            RuleFor(p => p.MoviesIds).NotEmpty();
            RuleFor(p => p.CustomerCpf)
                .NotEmpty()
                .MaximumLength(14)
                .Must(a => Cpf.IsValid(a)).WithMessage("CPF inválido");
        }
    }
}