using Application.Abstractions.Pipelines.Caching;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandRequest:IRequest<UpdatedCategoryCommandResponse>, ICacheRemoverRequest
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "category-list";
}