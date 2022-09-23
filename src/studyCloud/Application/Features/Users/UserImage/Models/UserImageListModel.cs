using Application.Features.Users.UserImage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Users.UserImage.Models;

public class UserImageListModel : BasePageableModel
{
    public IList<ListUserImageDto> Items { get; set; }
}