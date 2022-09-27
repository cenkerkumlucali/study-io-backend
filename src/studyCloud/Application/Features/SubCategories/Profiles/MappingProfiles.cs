using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.DeleteSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.SubCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Categories.SubCategory, CreatedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, CreateSubCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeletedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeleteSubCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdatedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdateSubCategoryCommand>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Categories.SubCategory>, SubCategoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, ListSubCategoryDto>()
            .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.Name)).ReverseMap();

        CreateMap<Domain.Entities.Categories.SubCategory, GetByIdSubCategoryDto>().ReverseMap();
    }
}