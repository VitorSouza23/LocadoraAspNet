using System;

namespace LocadoraAspNet.Controllers.Locations.ViewModels
{
    /// <summary>
    /// Dados do filme da locação
    /// </summary>
    public class LocationMovieViewModel
    {
        /// <summary>
        /// ID do filme
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Nome do filme
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Data de criação
        /// </summary>
        /// <value></value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }

        /// <summary>
        /// Dados do gênero do filme
        /// </summary>
        /// <value></value>
        public LocationGenreViewModel Genre { get; set; }
    }
}