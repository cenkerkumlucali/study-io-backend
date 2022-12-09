using Application.Repositories.Services.Categories;
using AutoMapper;
using Domain.Entities.Categories;
using MediatR;

namespace Application.Features.SubCategories.Queries.GetListByParentId;

public class GetListByParentIdQueryHandler:IRequestHandler<GetListByParentIdQueryRequest,List<GetListByParentIdQueryResponse>>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private IMapper _mapper;

    public GetListByParentIdQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetListByParentIdQueryResponse>> Handle(GetListByParentIdQueryRequest request, CancellationToken cancellationToken)
    {
        List<SubCategory> subCategories = await _subCategoryRepository.GetAllAsync(c=>c.ParentId == request.ParentId);
        List<GetListByParentIdQueryResponse>? mappedSubCategories = _mapper.Map<List<GetListByParentIdQueryResponse>>(subCategories);
        return mappedSubCategories;
    }
}