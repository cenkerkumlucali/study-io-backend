using Application.Features.Feeds.Post.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQueryRequest : IRequest<PostListModel>
{
    public PageRequest PageRequest { get; set; }

   
}