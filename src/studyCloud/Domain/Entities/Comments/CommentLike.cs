using Domain.Entities.Users;
using Domain.Entities.Common;

namespace Domain.Entities.Comments;

public class CommentLike : BaseEntity
{
    public long UserId { get; set; }
    public long CommentId { get; set; }
    public virtual User User { get; set; }
    public virtual Comment Comment { get; set; }

}