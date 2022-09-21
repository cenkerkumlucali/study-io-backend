using Application.Features.SubCategory.Commands;
using Application.Features.SubCategory.Commands.CreateSubCategory;
using Application.Features.SubCategory.Commands.DeleteSubCategory;
using Application.Features.SubCategory.Commands.UpdateSubCategory;
using Application.Features.SubCategory.Dtos;
using Application.Features.SubCategory.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.SubCategory.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Categories.SubCategory, CreatedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, CreateSubCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeletedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeleteSubCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdatedSubCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdateSubCategoryCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Categories.SubCategory>,SubCategoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory,ListSubCategoryDto>().ReverseMap();

        CreateMap<Domain.Entities.Categories.SubCategory, GetByIdSubCategoryDto>().ReverseMap();
    }
}