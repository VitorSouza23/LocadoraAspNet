using System;
using System.Collections.Generic;
using LocadoraAspNet.Models.Base;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Models.Features.Genres
{
    public class Genre : Entity
    {
        protected Genre() { }
        public Genre(string name, DateTime creationDate, bool active)
        {
            Name = name;
            CreationDate = creationDate;
            Active = active;
        }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public virtual IList<Movie> Movies { get; set; }
    }
}