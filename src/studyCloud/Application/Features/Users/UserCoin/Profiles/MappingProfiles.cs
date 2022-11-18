using Application.Abstractions.Services.Paging;
using Application.Features.Users.UserCoin.Commands.CreateUserCoin;
using Application.Features.Users.UserCoin.Commands.DeleteUserCoin;
using Application.Features.Users.UserCoin.Commands.UpdateUserCoin;
using Application.Features.Users.UserCoin.Models;
using Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;
using Application.Features.Users.UserCoin.Queries.GetListUserCoin;
using AutoMapper;

namespace Application.Features.Users.UserCoin.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Users.UserCoin, CreateUserCoinCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, CreateUserCoinCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, DeleteUserCoinCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, DeleteUserCoinCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, UpdateUserCoinCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, UpdateUserCoinCommandRequest>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Users.UserCoin>, UserCoinListModel>().ReverseMap();
        CreateMap<Domain.Entities.Users.UserCoin, ListUserCoinQueryResponse>()
            .ForMember(c => c.UserEmail, opt => opt.MapFrom(c => c.User.Email)).ReverseMap();

        CreateMap<Domain.Entities.Users.UserCoin, GetByIdUserCoinQueryResponse>().ReverseMap();
    }
}