using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.UserImage.Commands.CreateUserImage;

public class CreateUserImageCommandRequest:IRequest<CreateUserImageCommandResponse>
{
    public long UserId { get; set; }
    public IFormFileCollection Files { get; set; }

}