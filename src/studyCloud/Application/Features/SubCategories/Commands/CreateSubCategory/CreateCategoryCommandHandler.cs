using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.CreateSubCategory;

public class CreateCategoryCommandHandler:IRequestHandler<CreateSubCategoryCommandRequest,CreateSubCategoryCommandResponse>
{
    private readonly ISubCategoryRepository _subCategoryRepository;
    private readonly IMapper _mapper;


    public CreateCategoryCommandHandler(ISubCategoryRepository categoryRepository, IMapper mapper)
    {
        _subCategoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CreateSubCategoryCommandResponse> Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Categories.SubCategory mappedSubCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
        Domain.Entities.Categories.SubCategory createdSubCategory = await _subCategoryRepository.AddAsync(mappedSubCategory);
        CreateSubCategoryCommandResponse mappedCreateCategoryDto = _mapper.Map<CreateSubCategoryCommandResponse>(createdSubCategory);
        return mappedCreateCategoryDto;
    }
}