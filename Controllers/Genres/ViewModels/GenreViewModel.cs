using System;

namespace LocadoraAspNet.Controllers.Genres.ViewModels
{
    /// <summary>
    /// Dados do gênero
    /// </summary>
    public class GenreViewModel
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
        /// Data de criação
        /// </summary>
        /// <value></value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Status de ativação
        /// </summary>
        /// <value></value>
        public bool Active { get; set; }
    }
}