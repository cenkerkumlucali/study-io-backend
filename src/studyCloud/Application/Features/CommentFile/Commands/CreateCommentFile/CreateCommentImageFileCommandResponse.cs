namespace Application.Features.CommentFile.Commands.CreateCommentFile;

public class CreateCommentImageFileCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
}