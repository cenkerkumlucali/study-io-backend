using Application.Features.Post.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Post.Queries.GetListPost;

public class GetListPostQueryRequest : IRequest<PostListModel>
{
    public PageRequest PageRequest { get; set; }
}