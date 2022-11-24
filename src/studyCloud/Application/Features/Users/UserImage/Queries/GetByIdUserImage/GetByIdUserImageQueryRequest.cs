using MediatR;

namespace Application.Features.Users.UserImage.Queries.GetByIdUserImage;

public class GetByIdUserImageQueryRequest : IRequest<GetByIdUserImageQueryResponse>
{
    public int Id { get; set; }
   
}