using Application.DTOs.Paging;
using Application.Features.Mentions.Queries.GetListMention;

namespace Application.Features.Mentions.Models;

public class MentionListModel:BasePageableModel
{
    public IList<ListMentionQueryResponse> Items { get; set; }
}