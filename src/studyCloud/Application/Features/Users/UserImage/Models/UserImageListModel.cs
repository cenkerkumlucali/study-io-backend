using Application.DTOs.Paging;
using Application.Features.Users.UserImage.Dtos;

namespace Application.Features.Users.UserImage.Models;

public class UserImageListModel : BasePageableModel
{
    public IList<ListUserImageDto> Items { get; set; }
}