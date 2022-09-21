using Application.Features.Category.Commands;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Dtos;
using Application.Features.Category.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Category.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Categories.Category, CreatedCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, DeletedCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, DeleteCategoryCommand>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, UpdatedCategoryDto>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, UpdateCategoryCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Categories.Category>,CategoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category,ListCategoryDto>().ReverseMap();

        CreateMap<Domain.Entities.Categories.Category, GetByIdCategoryDto>().ReverseMap();
    }
}