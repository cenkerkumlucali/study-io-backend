using Application.Features.Feeds.PostLike.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetListPostLike;

public class GetListPostLikeQueryRequest : IRequest<PostLikeListModel>
{
    public PageRequest PageRequest { get; set; }
}