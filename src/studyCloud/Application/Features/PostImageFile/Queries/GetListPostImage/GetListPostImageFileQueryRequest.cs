using Application.Features.PostImageFile.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.PostImageFile.Queries.GetListPostImage;

public class GetListPostImageFileQueryRequest : IRequest<PostImageListModel>
{
    public PageRequest PageRequest { get; set; }
}