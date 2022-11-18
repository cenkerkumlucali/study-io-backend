using MediatR;

namespace Application.Features.Mentions.Queries.GetByIdMention;

public class GetByIdMentionQueryRequest:IRequest<GetByIdMentionQueryResponse>
{
    public int Id { get; set; }
    
}