using Application.Repositories.Services.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandHandler:IRequestHandler<DeleteSubCategoryCommandRequest,DeleteSubCategoryCommandResponse>
{
    private ISubCategoryRepository _subCategoryRepository;
    private IMapper _mapper;

    public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<DeleteSubCategoryCommandResponse> Handle(DeleteSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.SubCategory subCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
        Domain.Entities.Categories.SubCategory deletedSubCategory =
            await _subCategoryRepository.DeleteAsync(subCategory);
        DeleteSubCategoryCommandResponse deletedSubCategoryDto =
            _mapper.Map<DeleteSubCategoryCommandResponse>(deletedSubCategory);
        return deletedSubCategoryDto;
    }
}