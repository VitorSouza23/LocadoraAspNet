using AutoMapper;
using LocadoraAspNet.Models.Features.Genres;
using LocadoraAspNet.Models.Features.Locations;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Controllers.Locations.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Location, LocationViewModel>();
            CreateMap<Movie, LocationMovieViewModel>();
            CreateMap<Genre, LocationGenreViewModel>();
        }
    }
}