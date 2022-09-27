using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Dtos;
using Application.Features.Users.UserImage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Users.UserImage.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.UserImage, CreatedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, CreateUserImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, DeletedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, DeleteUserImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, UpdatedUserImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, UpdateUserImageCommand>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Users.UserImage>, UserImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserImage, ListUserImageDto>()
            .ForMember(c => c.UserEmail, opt => opt.MapFrom(c => c.User.Email)).ReverseMap();


        CreateMap<Domain.Entities.Users.UserImage, GetByIdUserImageDto>().ReverseMap();
    }
}