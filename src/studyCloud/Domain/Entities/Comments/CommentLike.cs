using Domain.Entities.Users;
using Domain.Entities.Common;

namespace Domain.Entities.Comments;

public class CommentLike : BaseEntity
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
    public virtual User User { get; set; }
    public virtual Comment Comment { get; set; }

}