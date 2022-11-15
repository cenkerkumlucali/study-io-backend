using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateCategoryCommandHandler:IRequestHandler<UpdateSubCategoryCommandRequest,UpdateSubCategoryCommandResponse>
{
    private ISubCategoryRepository _subCategoryRepository;
    private IMapper _mapper;

    public UpdateCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
    {
        _subCategoryRepository = subCategoryRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSubCategoryCommandResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.SubCategory subCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
        Domain.Entities.Categories.SubCategory updatedSubCategory =
            await _subCategoryRepository.UpdateAsync(subCategory);
        UpdateSubCategoryCommandResponse  updatedSubCategoryDto =
            _mapper.Map<UpdateSubCategoryCommandResponse>(updatedSubCategory);
        return updatedSubCategoryDto;
    }
}