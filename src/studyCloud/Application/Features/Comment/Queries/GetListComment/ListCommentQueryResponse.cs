using Application.Features.Post.Dtos;

namespace Application.Features.Comment.Queries.GetListComment;

public class ListCommentQueryResponse
{
    public int Id { get; set; }
    public string Content { get; set; }
    public ICollection<PostCommentDto?> Childrens { get; set; }
}