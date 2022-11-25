using Application.Abstractions.Pipelines.Authorization;
using Application.Abstractions.Pipelines.Caching;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandRequest:IRequest<CreatedCategoryCommandResponse>, ICacheRemoverRequest
{
    public string Name { get; set; }
    public bool BypassCache { get; }
    public string CacheKey => "category-list";
}