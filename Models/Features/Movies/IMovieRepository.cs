using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraAspNet.InfraData.Base;

namespace LocadoraAspNet.Models.Features.Movies
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<(Exception, IEnumerable<Movie>)> DeleteManyAsync(IEnumerable<int> movieIds);
    }
}