using System;

namespace LocadoraAspNet.Controllers.Genres.ViewModels
{
    public class GenreMovieViewModel
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
    }
}