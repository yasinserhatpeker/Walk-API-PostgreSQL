using System;
using AutoMapper;
using MyApp.Models;
using MyApp.Models.DTOs;

namespace MyApp.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Region, RegionDTO>().ReverseMap();
        CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
        CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();
        CreateMap<AddWalkRequestDTO, Walk>().ReverseMap();
        CreateMap<Walk,WalkDTO>().ReverseMap();
   }
}
