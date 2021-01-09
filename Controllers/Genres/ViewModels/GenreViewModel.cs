using System;
using System.Collections.Generic;

namespace LocadoraAspNet.Controllers.Genres.ViewModels
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<GenreMovieViewModel> Movies { get; set; }
    }
}