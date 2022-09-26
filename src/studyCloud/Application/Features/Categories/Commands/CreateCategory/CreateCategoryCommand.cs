using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<CreatedCategoryDto>
{
    public string Name { get; set; }
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,CreatedCategoryDto>
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

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryBusinessRules.CategoryNameCanNotBeDuplicatedWhenInserted(request.Name);
            
            Domain.Entities.Categories.Category mappedCategory = _mapper.Map<Domain.Entities.Categories.Category>(request);
            Domain.Entities.Categories.Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreatedCategoryDto mappedCreateCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);
            return mappedCreateCategoryDto;
        }
    }
}