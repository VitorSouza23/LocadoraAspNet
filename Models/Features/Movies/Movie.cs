using System;
using LocadoraAspNet.Models.Base;
using LocadoraAspNet.Models.Features.Genres;

namespace LocadoraAspNet.Models.Features.Movies
{
    public class Movie : Entity
    {
        protected Movie() { }
        public Movie(string name, DateTime creationDate, bool active, Genre genre)
        {
            Name = name;
            CreationDate = creationDate;
            Active = active;
            Genre = genre;
        }

        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}