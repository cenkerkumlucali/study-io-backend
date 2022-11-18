namespace Domain.Entities.Users;

public class UserImageFile: File
{
    public ICollection<User> Users { get; set; }
}