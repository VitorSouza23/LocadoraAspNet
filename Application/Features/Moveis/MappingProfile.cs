using AutoMapper;
using LocadoraAspNet.Application.Features.Movies.Commands;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Application.Features.Movies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddMovieCommand, Movie>();
            CreateMap<PutMovieCommand, Movie>();
        }
    }
}