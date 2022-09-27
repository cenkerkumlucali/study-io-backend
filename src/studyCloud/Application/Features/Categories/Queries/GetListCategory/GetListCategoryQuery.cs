using Application.Features.Categories.Models;
using Application.Services.Repositories.Categories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQuery : IRequest<CategoryListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, CategoryListModel>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryListModel> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Categories.Category> category =
                await _categoryRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            CategoryListModel mappedCategoryListModel =
                _mapper.Map<CategoryListModel>(category);
            return mappedCategoryListModel;
        }
    }
}