using MediatR;

namespace Application.Features.Feeds.PostImage.Queries.GetByIdPostImage;

public class GetByIdPostImageQueryRequest:IRequest<GetByIdPostFileQueryResponse>
{
    public int Id { get; set; }
    
}