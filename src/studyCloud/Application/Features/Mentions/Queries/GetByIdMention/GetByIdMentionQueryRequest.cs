using MediatR;

namespace Application.Features.Mentions.Queries.GetByIdMention;

public class GetByIdMentionQueryRequest:IRequest<GetByIdMentionQueryResponse>
{
    public long Id { get; set; }
    
}