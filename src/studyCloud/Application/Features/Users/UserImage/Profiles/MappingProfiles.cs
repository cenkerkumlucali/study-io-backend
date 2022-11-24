using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Models;
using Application.Features.Users.UserImage.Queries.GetByIdUserImage;
using Application.Features.Users.UserImage.Queries.GetListUserImage;
using AutoMapper;

namespace Application.Features.Users.UserImage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.UserImageFile, CreateUserImageCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, CreateUserImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, DeleteUserImageCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, DeleteUserImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, UpdateUserImageCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, UpdateUserImageCommandRequest>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Users.UserImageFile>, UserImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, ListUserImageQueryResponse>()
            .ForMember(c => c.UserEmail, opt => opt.MapFrom(c => c.Users)).ReverseMap();


        CreateMap<Domain.Entities.Users.UserImageFile, GetByIdUserImageQueryResponse>().ReverseMap();
    }
}