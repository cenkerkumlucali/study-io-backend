using Application.Features.Category.Dtos;
using Application.Services.Repositories.Categories;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetByIdCategory;

public class GetByIdCategoryQuery:IRequest<GetByIdCategoryDto>
{
    public int Id { get; set; }
    public class GetByIdCategoryQueryHandler:IRequestHandler<GetByIdCategoryQuery,GetByIdCategoryDto>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Categories.Category? category =
                await _categoryRepository.GetAsync(c => c.Id == request.Id);
            GetByIdCategoryDto getByIdCategoryDto =
                _mapper.Map<GetByIdCategoryDto>(category);
            return getByIdCategoryDto;
        }
    }
}