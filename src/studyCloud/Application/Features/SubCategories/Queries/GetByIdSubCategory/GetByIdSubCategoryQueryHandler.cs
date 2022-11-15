using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQueryHandler:IRequestHandler<GetByIdSubCategoryQueryRequest,GetByIdSubCategoryQueryResponse>
{
    private ISubCategoryRepository _subCategoryRepository;
    private IMapper _mapper;

    public GetByIdSubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdSubCategoryQueryResponse> Handle(GetByIdSubCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.SubCategory? subCategory =
            await _subCategoryRepository.GetAsync(c => c.Id == request.Id);
        GetByIdSubCategoryQueryResponse getByIdSubCategoryDto =
            _mapper.Map<GetByIdSubCategoryQueryResponse>(subCategory);
        return getByIdSubCategoryDto;
    }
}