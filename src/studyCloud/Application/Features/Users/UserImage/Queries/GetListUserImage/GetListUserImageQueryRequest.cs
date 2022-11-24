using Application.Features.Users.UserImage.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Users.UserImage.Queries.GetListUserImage;

public class GetListUserImageQueryRequest : IRequest<UserImageListModel>
{
    public PageRequest PageRequest { get; set; }

   
}