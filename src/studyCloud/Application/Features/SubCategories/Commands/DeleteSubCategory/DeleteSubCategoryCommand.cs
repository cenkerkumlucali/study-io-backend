using Application.Features.SubCategories.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommand:IRequest<DeletedSubCategoryDto>
{
    public int Id { get; set; }
    public class DeleteSubCategoryCommandHandler:IRequestHandler<DeleteSubCategoryCommand,DeletedSubCategoryDto>
    {
        private ISubCategoryRepository _subCategoryRepository;
        private IMapper _mapper;

        public DeleteSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<DeletedSubCategoryDto> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.SubCategory subCategory = _mapper.Map<Domain.Entities.Categories.SubCategory>(request);
            Domain.Entities.Categories.SubCategory deletedSubCategory =
                await _subCategoryRepository.DeleteAsync(subCategory);
            DeletedSubCategoryDto deletedSubCategoryDto =
                _mapper.Map<DeletedSubCategoryDto>(deletedSubCategory);
            return deletedSubCategoryDto;
        }
    }
}