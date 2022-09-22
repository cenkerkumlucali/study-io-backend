using Application.Features.Categories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand:IRequest<DeletedCategoryDto>
{
    public int Id { get; set; }
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand,DeletedCategoryDto>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.Category category = _mapper.Map<Domain.Entities.Categories.Category>(request);
            Domain.Entities.Categories.Category deletedCategory =
                await _categoryRepository.DeleteAsync(category);
            DeletedCategoryDto deletedCategoryDto =
                _mapper.Map<DeletedCategoryDto>(deletedCategory);
            return deletedCategoryDto;
        }
    }
}