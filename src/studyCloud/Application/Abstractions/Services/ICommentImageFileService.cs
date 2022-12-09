using Domain.Entities.Comments;
using Domain.Entities.ImageFile;

namespace Application.Abstractions.Services;

public interface ICommentImageFileService:IImageFileService<CommentImageFile>
{
}