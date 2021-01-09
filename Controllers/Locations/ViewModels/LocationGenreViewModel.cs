using System;

namespace LocadoraAspNet.Controllers.Locations.ViewModels
{
    /// <summary>
    /// Dados do gênero do filme
    /// </summary>
    public class LocationGenreViewModel
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