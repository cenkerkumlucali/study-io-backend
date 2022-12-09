using MediatR;

namespace Application.Features.Feeds.PostImageFile.Queries.GetByIdPostImage;

public class GetByIdPostImageQueryRequest:IRequest<GetByIdPostFileQueryResponse>
{
    public long Id { get; set; }
    
}