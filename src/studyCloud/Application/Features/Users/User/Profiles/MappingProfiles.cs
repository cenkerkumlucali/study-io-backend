using Application.Abstractions.Services.Paging;
using Application.Features.Post.Dtos;
using Application.Features.Users.User.Commands.CreateUser;
using Application.Features.Users.User.Commands.DeleteUser;
using Application.Features.Users.User.Commands.EditProfile;
using Application.Features.Users.User.Commands.UpdateUser;
using Application.Features.Users.User.Commands.UpdateUserFromAuth;
using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Models;
using Application.Features.Users.User.Queries.GetByIdUser;
using Application.Features.Users.User.Queries.GetListUser;
using Application.Features.Users.User.Queries.Profile;
using AutoMapper;

namespace Application.Features.Users.User.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.User, CreateUserCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, CreateUserCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, UpdateUserCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, UpdateUserCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, UpdateUserFromAuthCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, UpdatedUserFromAuthDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, DeleteUserCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, DeleteUserCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, GetByIdUserQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, ListUserQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, EditProfileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.User, EditProfileCommandResponse>().ReverseMap();
        CreateMap<ProfileDto, PostListDto>().ReverseMap();
        CreateMap<ProfileDto, ProfileQueryRequest>().ReverseMap();
        CreateMap<ProfileDto, ProfileQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Users.User>, UserListModel>().ReverseMap();
    }
}