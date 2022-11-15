using Application.Features.Feeds.PostImage.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetListPostImage;

public class GetListPostImageQueryRequest : IRequest<PostImageListModel>
{
    public PageRequest PageRequest { get; set; }
}