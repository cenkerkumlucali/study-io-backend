namespace Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int Content { get; set; }
    public string ImagePath { get; set; }
}