using Application.Features.Post.Dtos;

namespace Application.Features.Post.Queries.GetByIdPost;

public class GetByIdPostQueryResponse
{
    public string FullName { get; set; }
    public string ProfileImageUrl { get; set; }
    public string Content { get; set; }
    public int CommentCount { get; set; }
    public int PostLike { get; set; }
    public List<string> Urls { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<PostCommentDto> Comments { get; set; }
}   