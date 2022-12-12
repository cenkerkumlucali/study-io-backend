using Application.Features.PostLike.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.PostLike.Queries.GetListPostLike;

public class GetListPostLikeQueryRequest : IRequest<PostLikeListModel>
{
    public PageRequest PageRequest { get; set; }
}