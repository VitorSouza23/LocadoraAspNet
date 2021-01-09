using AutoMapper;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Controllers.Movies.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<Genre, MovieGenreViewModel>();
        }
    }
}