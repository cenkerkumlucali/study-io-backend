using Application.Features.Mentions.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Mentions.Models;

public class MentionListModel:BasePageableModel
{
    public IList<ListMentionDto> Items { get; set; }
}