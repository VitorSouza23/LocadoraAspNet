using System;
using System.Collections;
using System.Collections.Generic;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Queries
{
    /// <summary>
    /// Consulta de todos os gêneros de filmes
    /// </summary>
    public class GetAllGenresQuery : IRequest<(Exception, IEnumerable<Genre>)>
    {

    }
}