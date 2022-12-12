using MediatR;

namespace Application.Features.Quiz.Queries.GetByPublisherId;

public class GetByPublisherIdQueryRequest:IRequest<GetByPublisherIdQueryResponse>
{
    public long PublisherId { get; set; }
}