using MediatR;

namespace Application.Features.Users.UserImage.Commands.UpdateUserImage;

public class UpdateUserImageCommandRequest : IRequest<UpdateUserImageCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string ImagePath { get; set; }

    
}