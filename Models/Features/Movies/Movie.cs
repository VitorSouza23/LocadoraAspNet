using System;
using LocadoraAspNet.Models.Base;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Locations;

namespace LocadoraAspNet.Models.Features.Movies
{
    public class Movie : Entity
    {
        protected Movie()
        {
            CreationDate = DateTime.Now;
        }

        public Movie(string name, bool active, Genre genre) : this()
        {
            Name = name;
            Active = active;
            Genre = genre;
        }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public bool GenreIsActived() => Genre.Active;
    }
}