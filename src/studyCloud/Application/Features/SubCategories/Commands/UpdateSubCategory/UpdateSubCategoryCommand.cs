using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommand:IRequest<UpdatedSubCategoryDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateSubCategoryCommand,UpdatedSubCategoryDto>
    {
        private ISubCategoryRepository _subCategoryRepository;
        private IMapper _mapper;

        public UpdateCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedSubCategoryDto> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.SubCategory subCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
            Domain.Entities.Categories.SubCategory updatedSubCategory =
                await _subCategoryRepository.UpdateAsync(subCategory);
            UpdatedSubCategoryDto  updatedSubCategoryDto =
                _mapper.Map<UpdatedSubCategoryDto>(updatedSubCategory);
            return updatedSubCategoryDto;
        }
    }
}