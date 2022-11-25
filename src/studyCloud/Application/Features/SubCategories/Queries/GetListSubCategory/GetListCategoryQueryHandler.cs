using Application.Abstractions.Services.Paging;
using Application.Features.SubCategories.Models;
using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SubCategories.Queries.GetListSubCategory;

public class GetListCategoryQueryHandler : IRequestHandler<GetListSubCategoryQueryRequest, SubCategoryListModel>
{
    private ISubCategoryRepository _subCategoryRepository;
    private IMapper _mapper;

    public GetListCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<SubCategoryListModel> Handle(GetListSubCategoryQueryRequest request,
        CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Categories.SubCategory> subCategory =
            await _subCategoryRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c => c.Category));
        SubCategoryListModel mappedSubCategoryListModel =
            _mapper.Map<SubCategoryListModel>(subCategory);
        return mappedSubCategoryListModel;
    }
}