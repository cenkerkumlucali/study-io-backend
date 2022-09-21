using Core.Persistence.Repositories;

namespace Domain.Entities.Comments;

public class CommentImage:Entity
{
    public int CommentId { get; set; }
    public virtual Comment Comment { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }

    public CommentImage()
    {
        
    }

    public CommentImage(int id, int commentId, string imagePath, DateTime createDate) : this()
    {
        Id = id;
        CommentId = commentId;
        ImagePath = imagePath;
        CreateDate = createDate;
    }
}