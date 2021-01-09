using AutoMapper;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Controllers.Genres.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Movie, GenreMovieViewModel>();
        }
    }
}