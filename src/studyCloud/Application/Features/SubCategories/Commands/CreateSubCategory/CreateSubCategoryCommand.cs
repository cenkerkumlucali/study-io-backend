using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommand:IRequest<CreatedSubCategoryDto>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    public class CreateCategoryCommandHandler:IRequestHandler<CreateSubCategoryCommand,CreatedSubCategoryDto>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;


        public CreateCategoryCommandHandler(ISubCategoryRepository categoryRepository, IMapper mapper)
        {
            _subCategoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.SubCategory mappedSubCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
            Domain.Entities.Categories.SubCategory createdSubCategory = await _subCategoryRepository.AddAsync(mappedSubCategory);
            CreatedSubCategoryDto mappedCreateCategoryDto = _mapper.Map<CreatedSubCategoryDto>(createdSubCategory);
            return mappedCreateCategoryDto;
        }
    }
}