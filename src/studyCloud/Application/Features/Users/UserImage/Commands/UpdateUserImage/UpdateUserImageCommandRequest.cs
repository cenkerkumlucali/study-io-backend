using MediatR;

namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommandRequest : IRequest<UpdateUserImageCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string ImagePath { get; set; }

    
}