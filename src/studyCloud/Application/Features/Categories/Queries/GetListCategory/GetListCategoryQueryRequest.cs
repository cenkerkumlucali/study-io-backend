using Application.Abstractions.Pipelines.Caching;
using Application.Features.Categories.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Categories.Queries.GetListCategory;

public class GetListCategoryQueryRequest : IRequest<CategoryListModel>,ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "category-list";
    public TimeSpan? SlidingExpiration { get; }
}