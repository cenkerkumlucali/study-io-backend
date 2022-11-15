using Application.Abstractions.Services.Paging;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategory;
using AutoMapper;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Categories.Category, CreatedCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, CreateCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, DeletedCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, DeleteCategoryCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, UpdatedCategoryCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category, UpdateCategoryCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Categories.Category>,CategoryListModel>().ReverseMap();
        CreateMap<Domain.Entities.Categories.Category,ListCategoryQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Categories.Category, GetByIdCategoryCommandResponse>().ReverseMap();
    }
}