using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.User.Commands.EditProfile;

public class EditProfileCommandHandler:IRequestHandler<EditProfileCommandRequest,EditProfileCommandResponse>
{
    private readonly IUserService _userService;
    private IMapper _mapper;

    public EditProfileCommandHandler(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<EditProfileCommandResponse> Handle(EditProfileCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Users.User user = await _userService.GetById(request.Id);
        Domain.Entities.Users.User? mappedUser = _mapper.Map(request,user);
        Domain.Entities.Users.User updatedUser = await _userService.Update(mappedUser);
        EditProfileCommandResponse? mappedResponse = _mapper.Map<EditProfileCommandResponse>(updatedUser);
        return mappedResponse;
    }
}