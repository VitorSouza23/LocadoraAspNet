using System;
using System.Collections.Generic;
using System.Linq;
using LocadoraAspNet.Models.Base;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Models.Features.Locations
{
    public class Location : Entity
    {
        protected Location()
        {
            LocationDate = DateTime.Now;
        }

        public Location(IList<Movie> movies, DateTime locationDate, Cpf customerCpf) : this()
        {
            Movies = movies;
            CustomerCpf = customerCpf;
        }

        public virtual IList<Movie> Movies { get; set; }
        public DateTime LocationDate { get; set; }
        public virtual Cpf CustomerCpf { get; set; }

        public void SetMovies(IEnumerable<Movie> movies)
        {
            Movies = movies.ToList();
        }
    }
}