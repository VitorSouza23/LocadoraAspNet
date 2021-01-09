using LocadoraAspNet.InfraData.Base;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.InfraData.Features.Movies
{
    public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) : base(context)
        {
        }
    }
}