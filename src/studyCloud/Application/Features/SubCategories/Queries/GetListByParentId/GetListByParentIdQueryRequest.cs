using MediatR;

namespace Application.Features.SubCategories.Queries.GetListByParentId;

public class GetListByParentIdQueryRequest:IRequest<List<GetListByParentIdQueryResponse>>
{
    public long ParentId { get; set; }
}