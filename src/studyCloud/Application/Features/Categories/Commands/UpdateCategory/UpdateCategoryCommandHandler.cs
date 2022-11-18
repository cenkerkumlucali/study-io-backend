using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommandRequest,UpdatedCategoryCommandResponse>
{
    private ICategoryRepository _categoryRepository;
    private IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.Category category = _mapper.Map<Domain.Entities.Categories.Category >(request);
        Domain.Entities.Categories.Category createdCategory =
            await _categoryRepository.UpdateAsync(category);
        UpdatedCategoryCommandResponse  updatedCategoryDto =
            _mapper.Map<UpdatedCategoryCommandResponse>(createdCategory);
        return updatedCategoryDto;
    }
}