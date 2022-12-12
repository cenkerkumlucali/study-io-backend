using MediatR;

namespace Application.Features.Post.Commands.UpdatePost;

public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

   
}