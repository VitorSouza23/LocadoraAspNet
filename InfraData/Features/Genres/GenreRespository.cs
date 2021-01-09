using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocadoraAspNet.Exceptions;
using LocadoraAspNet.InfraData.Base;
using LocadoraAspNet.InfraData.Contexts;
using LocadoraAspNet.Models.Features.Genres;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAspNet.InfraData.Features.Genres
{
    public class GenreRepository : AbstractRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext context) : base(context)
        {
        }
    }
}