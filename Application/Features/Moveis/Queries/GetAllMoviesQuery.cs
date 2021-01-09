using System;
using System.Collections.Generic;
using LocadoraAspNet.Models.Features.Movies;
using MediatR;

namespace LocadoraAspNet.Application.Features.Movies.Queries
{
    public class GetAllMoviesQuery : IRequest<(Exception, IEnumerable<Movie>)>
    {

    }
}