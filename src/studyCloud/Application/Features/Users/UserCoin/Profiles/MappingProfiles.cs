using Application.Features.Users.UserCoin.Commands.CreateUserCoin;
using Application.Features.Users.UserCoin.Commands.DeleteUserCoin;
using Application.Features.Users.UserCoin.Commands.UpdateUserCoin;
using Application.Features.Users.UserCoin.Dtos;
using Application.Features.Users.UserCoin.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Users.UserCoin.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.UserCoin, CreatedUserCoinDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, CreateUserCoinCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, DeletedUserCoinDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, DeleteUserCoinCommand>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, UpdatedUserCoinDto>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, UpdateUserCoinCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Users.UserCoin>,UserCoinListModel>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin,ListUserCoinDto>().ReverseMap();

        CreateMap<Domain.Entities.Users.UserCoin, GetByIdUserCoinDto>().ReverseMap();
    }
}