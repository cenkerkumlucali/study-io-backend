using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Users;

public class UserImage:Entity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }

    public UserImage()
    {
        
    }

    public UserImage(int id, int userId, string imagePath, DateTime createDate) : this()
    {
        Id = id;
        UserId = userId;
        ImagePath = imagePath;
        CreateDate = createDate;
    }
}