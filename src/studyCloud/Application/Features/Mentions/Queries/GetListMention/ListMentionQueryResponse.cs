using Domain.Enums;

namespace Application.Features.Mentions.Queries.GetListMention;

public class ListMentionQueryResponse
{
    public long Id { get; set; }
    public string AgentEmail { get; set; }
    public string TargetEmail { get; set; }
    public string PostContent { get; set; }
    public string CommentContent { get; set; }
    public MentionType MentionType { get; set; }
    public DateTime CreatedDate { get; set; }
}