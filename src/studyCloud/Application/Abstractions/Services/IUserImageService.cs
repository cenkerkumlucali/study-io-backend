using Domain.Entities.ImageFile;
using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IUserImageService:IImageFileService<UserImageFile>
{
    
}