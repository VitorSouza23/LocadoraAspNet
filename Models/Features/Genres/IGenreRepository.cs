using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocadoraAspNet.Models.Features.Genres
{
    public interface IGenreRepository
    {
        Task<(Exception, Genre)> AddAsync(Genre genre);
        Task<(Exception, IEnumerable<Genre>)> GetAllAsync();
        Task<(Exception, Genre)> GetByIdAsync(int id);
        Task<(Exception, Genre)> UpdateAsync(Genre genre);
        Task<(Exception, Genre)> DeleteAsync(int id);

    }
}