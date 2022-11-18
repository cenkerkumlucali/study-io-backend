using Domain.Entities.Comments;
using Domain.Entities.Users;
using Domain.Entities.Common;

namespace Domain.Entities.Feeds;

public class Post : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Content { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<PostLike>? PostLikes { get; set; }
    public ICollection<PostImageFile> PostImageFiles { get; set; }

    public Post()
    {
    }

    public Post(int id, int userId, string content, DateTime createdDate) : this()
    {
        Id = id;
        UserId = userId;
        Content = content;
        CreatedDate = createdDate;
    }
}