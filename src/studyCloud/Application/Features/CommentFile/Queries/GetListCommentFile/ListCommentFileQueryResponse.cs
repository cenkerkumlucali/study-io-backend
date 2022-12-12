namespace Application.Features.CommentFile.Queries.GetListCommentFile;

public class ListCommentFileQueryResponse
{
    public int Id { get; set; }
    public Domain.Entities.Comments.Comment Comment { get; set; }
    public int Content { get; set; }
    public string ImagePath { get; set; }
}