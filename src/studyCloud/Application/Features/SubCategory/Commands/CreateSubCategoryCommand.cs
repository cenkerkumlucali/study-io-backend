using Application.Features.Category.Commands;
using Application.Features.Category.Dtos;
using Application.Features.SubCategory.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategory.Commands;

public class CreateSubCategoryCommand:IRequest<CreateSubCategoryDto>
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    
    public class CreateCategoryCommandHandler:IRequestHandler<CreateSubCategoryCommand,CreateSubCategoryDto>
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IMapper _mapper;


        public CreateCategoryCommandHandler(ISubCategoryRepository categoryRepository, IMapper mapper)
        {
            _subCategoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateSubCategoryDto> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.SubCategory mappedSubCategory = _mapper.Map<Domain.Entities.SubCategory>(request);
            Domain.Entities.SubCategory createdSubCategory = await _subCategoryRepository.AddAsync(mappedSubCategory);
            CreateSubCategoryDto mappedCreateCategoryDto = _mapper.Map<CreateSubCategoryDto>(createdSubCategory);
            return mappedCreateCategoryDto;
        }
    }
}