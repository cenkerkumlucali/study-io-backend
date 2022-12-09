using Domain.Entities.Users;

namespace Domain.Entities.ImageFile;

public class UserImageFile: File
{
    public ICollection<User> Users { get; set; }
}