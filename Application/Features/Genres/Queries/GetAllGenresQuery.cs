using System;
using System.Collections;
using System.Collections.Generic;
using LocadoraAspNet.Models.Features.Genres;
using MediatR;

namespace LocadoraAspNet.Application.Features.Genres.Queries
{
    public class GetAllGenresQuery : IRequest<(Exception, IEnumerable<Genre>)>
    {

    }
}