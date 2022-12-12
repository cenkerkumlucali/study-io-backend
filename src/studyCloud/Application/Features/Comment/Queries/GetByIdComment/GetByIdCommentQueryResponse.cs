namespace Application.Features.Comment.Queries.GetByIdComment;

public class GetByIdCommentQueryResponse
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}