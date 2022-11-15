using Application.Features.SubCategories.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.SubCategories.Queries.GetListSubCategory;

public class GetListSubCategoryQueryRequest : IRequest<SubCategoryListModel>
{
    public PageRequest PageRequest { get; set; }
}