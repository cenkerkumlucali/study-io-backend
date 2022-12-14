using Application.Abstractions.Services.Paging;
using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.DeleteSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using Application.Features.SubCategories.Queries.GetByIdSubCategory;
using Application.Features.SubCategories.Queries.GetListByParentId;
using Application.Features.SubCategories.Queries.GetListSubCategory;
using AutoMapper;

namespace Application.Features.SubCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Categories.SubCategory, CreateSubCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, CreateSubCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeleteSubCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, DeleteSubCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdateSubCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, UpdateSubCategoryCommandRequest>().ReverseMap();

    

        CreateMap<Domain.Entities.Categories.SubCategory, LessonSubCategoryDto>()
            .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
            .ForMember(c => c.Lessons, opt => opt.MapFrom(c => c.Lessons))
            .ForMember(c => c.Children, opt => opt.MapFrom(c => c.Children ))
            .ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Categories.SubCategory>, SubCategoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, ListSubCategoryQueryResponse>()
            .ForMember(c => c.CategoryName, opt => opt.MapFrom(c => c.Category.Name)).ReverseMap();

        CreateMap<Domain.Entities.Categories.SubCategory, GetByIdSubCategoryQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.SubCategory, GetListByParentIdQueryResponse>().ReverseMap();
    }
}