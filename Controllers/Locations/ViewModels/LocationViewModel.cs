using System;
using System.Collections.Generic;

namespace LocadoraAspNet.Controllers.Locations.ViewModels
{
    /// <summary>
    /// Dados da locação
    /// </summary>
    public class LocationViewModel
    {
        /// <summary>
        /// ID da locação
        /// </summary>
        /// <value></value>
        public int Id { get; set; }

        /// <summary>
        /// Lista de filmes da locação
        /// </summary>
        /// <value></value>
        public IEnumerable<LocationMovieViewModel> Movies { get; set; }

        /// <summary>
        /// Data da locação
        /// </summary>
        /// <value></value>
        public DateTime LocationDate { get; set; }

        /// <summary>
        /// CPF do cliente
        /// </summary>
        /// <value></value>
        public string CustomerCpf { get; set; }
    }
}