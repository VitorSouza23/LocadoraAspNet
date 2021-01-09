using System.Linq;
using AutoMapper;
using LocadoraAspNet.Application.Features.Locations.Commands;
using LocadoraAspNet.Models.Features.Locations;
using LocadoraAspNet.Models.Features.Movies;

namespace LocadoraAspNet.Application.Features.Locations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddLocationCommand, Location>();
            CreateMap<PutLocationCommand, Location>();
        }
    }
}