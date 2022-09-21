using Application.Features.Category.Dtos;
using Application.Features.SubCategory.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.SubCategory.Queries.GetByIdSubCategory;

public class GetByIdSubCategoryQuery:IRequest<GetByIdSubCategoryDto>
{
    public int Id { get; set; }
    public class GetByIdSubCategoryQueryHandler:IRequestHandler<GetByIdSubCategoryQuery,GetByIdSubCategoryDto>
    {
        private ISubCategoryRepository _subCategoryRepository;
        private IMapper _mapper;

        public GetByIdSubCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdSubCategoryDto> Handle(GetByIdSubCategoryQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.SubCategory? subCategory =
                await _subCategoryRepository.GetAsync(c => c.Id == request.Id);
            GetByIdSubCategoryDto getByIdSubCategoryDto =
                _mapper.Map<GetByIdSubCategoryDto>(subCategory);
            return getByIdSubCategoryDto;
        }
    }
}