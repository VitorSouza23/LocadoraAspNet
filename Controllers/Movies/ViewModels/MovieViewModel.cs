using System;

namespace LocadoraAspNet.Controllers.Movies.ViewModels
{
    /// <summary>
    /// Dados do filme
    /// </summary>
    public class MovieViewModel
    {
        /// <summary>
        /// Id do filme
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Nome do filme
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Data de criação do filme
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
        public MovieGenreViewModel Genre { get; set; }

    }
}