using MediatR;

namespace Application.Features.CommentFile.Commands.UpdateCommentFile;

public class UpdateCommentFileCommandRequest:IRequest<UpdateCommentFileCommandResponse>
{
    public long Id { get; set; }
    public long CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
}