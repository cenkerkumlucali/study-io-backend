using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities.Comments;

namespace Domain.Entities.Feeds;

public class Post:Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual List<Comment> Comments { get; set; }
    public virtual List<PostLike> PostLikes { get; set; }

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