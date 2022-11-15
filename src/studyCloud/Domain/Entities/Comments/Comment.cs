using Domain.Entities.Users;
using Domain.Entities.Common;

namespace Domain.Entities.Comments;

public class Comment:BaseEntity
{
    public int? ParentId {get; set;}
    public virtual Comment Parent { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Content { get; set; }
    public virtual List<Comment> Childrens { get; set; }
    public virtual List<CommentLike> CommentLikes { get; set; }

}