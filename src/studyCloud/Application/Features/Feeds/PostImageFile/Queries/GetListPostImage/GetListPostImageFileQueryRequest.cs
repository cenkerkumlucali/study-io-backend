using Application.Features.Feeds.PostImageFile.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Feeds.PostImageFile.Queries.GetListPostImage;

public class GetListPostImageFileQueryRequest : IRequest<PostImageListModel>
{
    public PageRequest PageRequest { get; set; }
}