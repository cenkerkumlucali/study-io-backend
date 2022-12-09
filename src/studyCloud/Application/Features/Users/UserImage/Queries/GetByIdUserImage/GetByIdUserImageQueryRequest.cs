using MediatR;

namespace Application.Features.Users.UserImage.Queries.GetByIdUserImage;

public class GetByIdUserImageQueryRequest : IRequest<GetByIdUserImageQueryResponse>
{
    public long Id { get; set; }
   
}