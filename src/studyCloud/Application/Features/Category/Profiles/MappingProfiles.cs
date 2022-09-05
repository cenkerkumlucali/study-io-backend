using Application.Features.Category.Commands;
using Application.Features.Category.Dtos;
using AutoMapper;

namespace Application.Features.Category.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Category, CreateCategoryCommand>().ReverseMap();
    }
}