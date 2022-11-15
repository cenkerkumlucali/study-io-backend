using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.UpdateCommentFile;

public class UpdateCommentFileCommandRequest:IRequest<UpdateCommentFileCommandResponse>
{
    public int Id { get; set; }
    public int CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
}