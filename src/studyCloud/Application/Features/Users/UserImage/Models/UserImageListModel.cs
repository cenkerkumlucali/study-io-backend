using Application.DTOs.Paging;
using Application.Features.Users.UserImage.Queries.GetListUserImage;

namespace Application.Features.Users.UserImage.Models;

public class UserImageListModel : BasePageableModel
{
    public IList<ListUserImageQueryResponse> Items { get; set; }
}