using Application.Features.Mentions.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Mentions.Queries.GetListMention;

public class GetListMentionQueryRequest : IRequest<MentionListModel>
{
    public PageRequest PageRequest { get; set; }
}