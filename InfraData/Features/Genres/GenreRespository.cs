using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Genres;
using Microsoft.EntityFrameworkCore;

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

        public async Task<(Exception, Genre)> DeleteAsync(int id)
        {
            Genre deletedGenre;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                deletedGenre = await _context.Genres.FindAsync(id);
                if (deletedGenre == null)
                {
                    await transaction.RollbackAsync();
                    return (new NotFoundException(), null);
                }
                _context.Genres.Remove(deletedGenre);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, deletedGenre);
        }

        public async Task<(Exception, IEnumerable<Genre>)> GetAllAsync()
        {
            try
            {
                var genres = await _context.Genres.ToListAsync();
                return (null, genres);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public async Task<(Exception, Genre)> GetByIdAsync(int id)
        {
            try
            {
                var genre = await _context.Genres.FindAsync(id);
                if (genre == null)
                    return (new NotFoundException(), null);
                return (null, genre);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public async Task<(Exception, Genre)> UpdateAsync(Genre genre)
        {
            Genre updatedGenre;
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                updatedGenre = _context.Genres.Update(genre).Entity;
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return (ex, null);
            }

            return (null, updatedGenre);
        }
    }
}