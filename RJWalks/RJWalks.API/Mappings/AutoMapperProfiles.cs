using AutoMapper;
using RJWalks.API.Models.Domain;
using RJWalks.API.Models.DTOs;

namespace RJWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();

        }
    }
}
