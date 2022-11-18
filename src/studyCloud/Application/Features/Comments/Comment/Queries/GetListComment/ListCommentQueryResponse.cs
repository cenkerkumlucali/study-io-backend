namespace Application.Features.Comments.Comment.Queries.GetListComment;

public class ListCommentQueryResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public ICollection<Domain.Entities.Comments.Comment?> Childrens { get; set; }
}