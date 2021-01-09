using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.InfraData.Base;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Movies;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.InfraData.Features.Movies
{
    public class MovieRepository : AbstractRepository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) : base(context)
        {
        }

        protected override IQueryable<Movie> FindByIdCustomQuery() => _context.Movies.Include(m => m.Genre).AsQueryable();
        protected override IQueryable<Movie> FindAllCustomQuery() => _context.Movies.Include(m => m.Genre).AsQueryable();

        public async Task<(Exception, IEnumerable<Movie>)> DeleteManyAsync(IEnumerable<int> movieIds)
        {
            IEnumerable<Movie> deletedMovies;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                deletedMovies = await _context.Movies.Include(m => m.Genre).Where(m => movieIds.Any(i => i == m.Id)).ToListAsync();
                if (movieIds.Except(deletedMovies.Select(m => m.Id)).Any())
                {
                    await transaction.RollbackAsync();
                    return (new NotFoundException("A lista de exclusão contém filmes que não existem na base"), null);
                }
                _context.Movies.RemoveRange(deletedMovies);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, deletedMovies);
        }

        public async Task<(Exception, IEnumerable<Movie>)> GetManyAsync(params int[] movieIds)
        {
            try
            {
                var movies = await _context.Movies.Include(m => m.Genre).Where(m => movieIds.Contains(m.Id)).ToListAsync();
                if (movieIds.Except(movies.Select(m => m.Id)).Any())
                    return (new NotFoundException("Nem todos os filmes solicitados foram encontrados na base"), null);

                return (null, movies);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}