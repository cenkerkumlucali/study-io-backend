using Application.Features.Categories.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQueryRequest : IRequest<CategoryListModel>
{
    public PageRequest PageRequest { get; set; }
}