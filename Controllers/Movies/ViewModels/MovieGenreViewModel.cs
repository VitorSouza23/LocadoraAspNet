using System;

namespace LocadoraAspNet.Controllers.Movies.ViewModels
{
    /// <summary>
    /// Dados do gênero do filme
    /// </summary>
    public class MovieGenreViewModel
    {
        /// <summary>
        /// ID do gênero
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Nome do gênero
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }
    }
}