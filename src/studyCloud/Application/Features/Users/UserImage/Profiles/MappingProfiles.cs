using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Dtos;
using Application.Features.Users.UserImage.Models;
using AutoMapper;

namespace Application.Features.Users.UserImage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.UserImageFile, CreatedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, CreateUserImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, DeletedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, DeleteUserImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, UpdatedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, UpdateUserImageCommand>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Users.UserImageFile>, UserImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImageFile, ListUserImageDto>()
            .ForMember(c => c.UserEmail, opt => opt.MapFrom(c => c.Users)).ReverseMap();


        CreateMap<Domain.Entities.Users.UserImageFile, GetByIdUserImageDto>().ReverseMap();
    }
}