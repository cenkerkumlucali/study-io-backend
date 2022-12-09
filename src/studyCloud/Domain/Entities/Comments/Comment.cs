using Domain.Entities.Users;
using Domain.Entities.Common;
using Domain.Entities.Feeds;
using Domain.Entities.ImageFile;

namespace Domain.Entities.Comments;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public long PostId { get; set; }
    public long UserId { get; set; }
    public long? ParentId { get; set; }
    public virtual Post Post { get; set; }
    public virtual Comment Parent { get; set; }
    public virtual User User { get; set; }
    public virtual List<Comment>? Children { get; set; }
    public virtual List<CommentLike>? CommentLikes { get; set; }
    public virtual ICollection<CommentImageFile>? CommentImageFiles { get; set; }

}