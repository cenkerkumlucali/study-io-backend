using Application.Features.Category.Commands;
using Application.Features.SubCategory.Commands;
using Application.Features.SubCategory.Dtos;
using AutoMapper;

namespace Application.Features.SubCategory.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.SubCategory, CreateSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.SubCategory, CreateSubCategoryCommand>().ReverseMap();
    }
}