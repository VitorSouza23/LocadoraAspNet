using System;
using System.Threading.Tasks;

namespace LocadoraAspNet.Models.Features.Genres
{
    public interface IGenreRepository
    {
        Task<(Exception, Genre)> AddAsync(Genre genre);
    }
}