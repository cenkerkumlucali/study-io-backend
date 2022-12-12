using MediatR;

namespace Application.Features.PostImageFile.Queries.GetByIdPostImage;

public class GetByIdPostImageQueryRequest:IRequest<GetByIdPostFileQueryResponse>
{
    public long Id { get; set; }
    
}