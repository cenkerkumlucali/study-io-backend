using MediatR;

namespace Application.Features.Users.UserImage.Commands.DeleteUserImage;

public class DeleteUserImageCommandRequest:IRequest<DeleteUserImageCommandResponse>
{
    public int Id { get; set; }
    
}