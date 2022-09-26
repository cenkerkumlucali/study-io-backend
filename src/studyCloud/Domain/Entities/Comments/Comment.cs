using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Comments;

public class Comment:Entity
{

    public int? ParentId {get; set;}
    public virtual Comment Parent { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual List<Comment> Childrens { get; set; }
    public virtual List<CommentLike> CommentLikes { get; set; }

    public Comment()
    {
        
    }

    public Comment(int id,int parentId, int userId, string content, DateTime createdDate) : this()
    {
        Id = id;
        ParentId = parentId;
        UserId = userId;
        Content = content;
        CreatedDate = createdDate;
    }
}