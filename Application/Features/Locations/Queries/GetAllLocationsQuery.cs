using System;
using System.Collections;
using System.Collections.Generic;
using LocadoraAspNet.Models.Features.Locations;
using MediatR;

namespace LocadoraAspNet.Application.Features.Locations.Queries
{
    /// <summary>
    /// Consulta todas as locações
    /// </summary>
    public class GetAllLocationsQuery : IRequest<(Exception, IEnumerable<Location>)>
    {

    }
}