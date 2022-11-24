using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.Users.UserImage.Commands.CreateUserImage;

public class CreateUserImageCommandHandler:IRequestHandler<CreateUserImageCommandRequest,CreateUserImageCommandResponse>
{
    private readonly IUserImageService _userImageService;

    public CreateUserImageCommandHandler(IUserImageService userImageService)
    {
        _userImageService = userImageService;
    }

    public async Task<CreateUserImageCommandResponse> Handle(CreateUserImageCommandRequest request, CancellationToken cancellationToken)
    {
        await _userImageService.Upload(request.UserId, request.Files);
        return new();
    }
}