using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommandRequest,DeletedCategoryCommandResponse>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<DeletedCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.Category category = _mapper.Map<Domain.Entities.Categories.Category>(request);
        Domain.Entities.Categories.Category deletedCategory =
            await _categoryRepository.DeleteAsync(category);
        DeletedCategoryCommandResponse deletedCategoryDto =
            _mapper.Map<DeletedCategoryCommandResponse>(deletedCategory);
        return deletedCategoryDto;
    }
}