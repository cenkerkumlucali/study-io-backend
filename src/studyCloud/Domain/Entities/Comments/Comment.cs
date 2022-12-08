using Domain.Entities.Users;
using Domain.Entities.Common;
using Domain.Entities.Feeds;

namespace Domain.Entities.Comments;

public class Comment : BaseEntity
{
    public int PostId { get; set; }
    public virtual Post Post { get; set; }

    public int? ParentId { get; set; }
    public virtual Comment Parent { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Content { get; set; }
    public virtual List<Comment>? Children { get; set; }
    public virtual List<CommentLike>? CommentLikes { get; set; }
    public virtual ICollection<CommentImageFile>? CommentImageFiles { get; set; }

}