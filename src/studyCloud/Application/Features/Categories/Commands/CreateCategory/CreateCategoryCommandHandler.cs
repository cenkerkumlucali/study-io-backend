using Application.Features.Categories.Rules;
using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommandRequest,CreatedCategoryCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;


    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<CreatedCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);
            
        Domain.Entities.Categories.Category mappedCategory = _mapper.Map<Domain.Entities.Categories.Category>(request);
        Domain.Entities.Categories.Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
        CreatedCategoryCommandResponse mappedCreateCategoryDto = _mapper.Map<CreatedCategoryCommandResponse>(createdCategory);
        return mappedCreateCategoryDto;
    }
}