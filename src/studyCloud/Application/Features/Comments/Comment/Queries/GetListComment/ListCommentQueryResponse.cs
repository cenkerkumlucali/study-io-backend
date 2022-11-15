namespace Application.Features.Comments.Comment.Queries.GetListComment;

public class ListCommentQueryResponse
{
    public int Id { get; set; }
    public Domain.Entities.Comments.Comment? ParentId { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}