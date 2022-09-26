using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Queries.GetByIdCategory;

public class GetByIdCategoryQuery:IRequest<GetByIdCategoryDto>
{
    public int Id { get; set; }
    public class GetByIdCategoryQueryHandler:IRequestHandler<GetByIdCategoryQuery,GetByIdCategoryDto>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;
        private CategoryBusinessRules _categoryBusinessRules;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryBusinessRules = categoryBusinessRules;
        }

        public async Task<GetByIdCategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            
            Domain.Entities.Categories.Category? category =
                await _categoryRepository.GetAsync(c => c.Id == request.Id);
            _categoryBusinessRules.CategoryShouldExistWhenRequested(category);

            GetByIdCategoryDto getByIdCategoryDto =
                _mapper.Map<GetByIdCategoryDto>(category);
            return getByIdCategoryDto;
        }
    }
}