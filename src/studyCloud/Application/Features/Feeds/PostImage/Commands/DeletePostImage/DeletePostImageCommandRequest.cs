using Application.Features.Feeds.PostImage.Dtos;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.DeletePostImage;

public class DeletePostImageCommandRequest:IRequest<DeletePostFileCommandResponse>
{
    public int Id { get; set; }
    
}