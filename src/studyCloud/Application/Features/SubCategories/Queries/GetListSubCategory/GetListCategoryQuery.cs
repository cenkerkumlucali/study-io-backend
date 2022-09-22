using Application.Features.SubCategories.Models;
using Application.Services.Repositories.Categories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SubCategories.Queries.GetListSubCategory;

public class GetListSubCategoryQuery : IRequest<SubCategoryListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListSubCategoryQuery, SubCategoryListModel>
    {
        private ISubCategoryRepository _subCategoryRepository;
        private IMapper _mapper;

        public GetListCategoryQueryHandler(ISubCategoryRepository subCategoryRepository, IMapper mapper)
        {
            _subCategoryRepository = subCategoryRepository;
            _mapper = mapper;
        }

        public async Task<SubCategoryListModel> Handle(GetListSubCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Categories.SubCategory> subCategory =
                await _subCategoryRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            SubCategoryListModel mappedSubCategoryListModel =
                _mapper.Map<SubCategoryListModel>(subCategory);
            return mappedSubCategoryListModel;
        }
    }
}