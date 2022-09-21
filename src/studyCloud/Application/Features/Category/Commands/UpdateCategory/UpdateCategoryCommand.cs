using Application.Features.Category.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand:IRequest<UpdatedCategoryDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommand,UpdatedCategoryDto>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.Category category = _mapper.Map<Domain.Entities.Categories.Category >(request);
            Domain.Entities.Categories.Category createdCategory =
                await _categoryRepository.UpdateAsync(category);
            UpdatedCategoryDto  updatedCategoryDto =
                _mapper.Map<UpdatedCategoryDto>(createdCategory);
            return updatedCategoryDto;
        }
    }
}