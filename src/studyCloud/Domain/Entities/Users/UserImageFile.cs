namespace Domain.Entities.Users;

public class UserImageFile: File.File
{
    public List<User> Users { get; set; }
}