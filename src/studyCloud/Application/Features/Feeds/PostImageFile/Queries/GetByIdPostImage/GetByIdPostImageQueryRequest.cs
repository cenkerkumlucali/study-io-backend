using MediatR;

namespace Application.Features.Feeds.PostImageFile.Queries.GetByIdPostImage;

public class GetByIdPostImageQueryRequest:IRequest<GetByIdPostFileQueryResponse>
{
    public int Id { get; set; }
    
}