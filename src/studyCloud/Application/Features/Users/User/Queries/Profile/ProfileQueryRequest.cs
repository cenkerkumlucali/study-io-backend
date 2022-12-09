using MediatR;

namespace Application.Features.Users.User.Queries.Profile;

public class ProfileQueryRequest:IRequest<ProfileQueryResponse>
{
    public long MemberId { get; set; }
    public long TargetId { get; set; }
}