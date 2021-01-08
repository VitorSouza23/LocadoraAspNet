using System;
using System.Collections.Generic;
using LocadoraAspNet.Models.Base;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Models.Features.Locations
{
    public class Location : Entity
    {
        public virtual List<Movie> Movies { get; set; }
        public DateTime LocationDate { get; set; }
        public virtual Cpf CustomerCpf { get; set; }
    }
}