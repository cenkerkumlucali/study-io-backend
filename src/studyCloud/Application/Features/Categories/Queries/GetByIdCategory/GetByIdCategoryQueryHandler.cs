using Application.Features.Categories.Rules;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQueryHandler:IRequestHandler<GetByIdCategoryQueryRequest,GetByIdCategoryCommandResponse>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;
    private CategoryBusinessRules _categoryBusinessRules;

    public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<GetByIdCategoryCommandResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
    {
            
        Domain.Entities.Categories.Category? category =
            await _categoryRepository.GetAsync(c => c.Id == request.Id);
        _categoryBusinessRules.CategoryShouldExistWhenRequested(category);

        GetByIdCategoryCommandResponse getByIdCategoryDto =
            _mapper.Map<GetByIdCategoryCommandResponse>(category);
        return getByIdCategoryDto;
    }
}