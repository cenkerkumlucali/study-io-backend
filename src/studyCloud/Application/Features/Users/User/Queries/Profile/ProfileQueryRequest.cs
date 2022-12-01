using MediatR;

namespace Application.Features.Users.User.Queries.Profile;

public class ProfileQueryRequest:IRequest<ProfileQueryResponse>
{
    public int MemberId { get; set; }
    public int TargetId { get; set; }
}