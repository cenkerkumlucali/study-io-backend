using Application.Abstractions.Services.Paging;
using Application.Features.Categories.Models;
using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQueryRequest, CategoryListModel>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryListModel> Handle(GetListCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Categories.Category> category =
            await _categoryRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        CategoryListModel mappedCategoryListModel =
            _mapper.Map<CategoryListModel>(category);
        return mappedCategoryListModel;
    }
}