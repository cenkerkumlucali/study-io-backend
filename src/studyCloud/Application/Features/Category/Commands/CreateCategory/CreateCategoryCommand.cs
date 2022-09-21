using Application.Features.Category.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<CreatedCategoryDto>
{
    public string Name { get; set; }
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,CreatedCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.Category mappedCategory = _mapper.Map<Domain.Entities.Categories.Category>(request);
            Domain.Entities.Categories.Category createdCategory = await _categoryRepository.AddAsync(mappedCategory);
            CreatedCategoryDto mappedCreateCategoryDto = _mapper.Map<CreatedCategoryDto>(createdCategory);
            return mappedCreateCategoryDto;
        }
    }
}