using AutoMapper;
using LocadoraAspNet.Application.Features.Genres.Commands;
using LocadoraAspNet.Models.Features.Genres;

namespace LocadoraAspNet.Application.Features.Genres
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddGenreCommand, Genre>();
        }
    }
}