using Application.Features.Search.Queries;
using Application.Features.Users.User.Dtos;
using AutoMapper;

namespace Application.Features.Search.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserDto, GetUserQueryResponse>().ReverseMap();
    }
}