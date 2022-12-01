using Application.Abstractions.Services;
using Application.Features.Users.User.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Queries.Profile;

public class ProfileQueryHandler : IRequestHandler<ProfileQueryRequest, ProfileQueryResponse>
{
    private readonly IUserService _userService;
    private IMapper _mapper;

    public ProfileQueryHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<ProfileQueryResponse> Handle(ProfileQueryRequest request, CancellationToken cancellationToken)
    {
        ProfileDto profile = await _userService.GetUserProfile(request.TargetId, request.MemberId);
        ProfileQueryResponse? mappedProfile = _mapper.Map<ProfileQueryResponse>(profile);
        return mappedProfile;
    }
}