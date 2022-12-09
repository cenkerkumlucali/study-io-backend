using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Models;
using Application.Features.Users.UserImage.Queries.GetByIdUserImage;
using Application.Features.Users.UserImage.Queries.GetListUserImage;
using AutoMapper;
using Domain.Entities.ImageFile;

namespace Application.Features.Users.UserImage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserImageFile, CreateUserImageCommandResponse>().ReverseMap();
        CreateMap<UserImageFile, CreateUserImageCommandRequest>().ReverseMap();
        CreateMap<UserImageFile, DeleteUserImageCommandResponse>().ReverseMap();
        CreateMap<UserImageFile, DeleteUserImageCommandRequest>().ReverseMap();
        CreateMap<UserImageFile, UpdateUserImageCommandResponse>().ReverseMap();
        CreateMap<UserImageFile, UpdateUserImageCommandRequest>().ReverseMap();

        CreateMap<IPaginate<UserImageFile>, UserImageListModel>().ReverseMap();
        CreateMap<UserImageFile, ListUserImageQueryResponse>()
            .ForMember(c => c.UserEmail, opt => opt.MapFrom(c => c.Users)).ReverseMap();


        CreateMap<UserImageFile, GetByIdUserImageQueryResponse>().ReverseMap();
    }
}