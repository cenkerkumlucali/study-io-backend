using Application.Abstractions.Pipelines.Caching;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest:IRequest<DeletedCategoryCommandResponse>, ICacheRemoverRequest
{
    public long Id { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "category-list";
}