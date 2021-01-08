using System;
using System.Threading.Tasks;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Genres;

namespace LocadoraAspNet.InfraData.Features.Genres
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;

        public GenreRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<(Exception, Genre)> AddAsync(Genre genre)
        {
            Genre newGenre;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                newGenre = _context.Genres.Add(genre).Entity;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, newGenre);
        }
    }
}