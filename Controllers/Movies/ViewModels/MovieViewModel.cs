using System;

namespace LocadoraAspNet.Controllers.Movies.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public MovieGenreViewModel Genre { get; set; }

    }
}