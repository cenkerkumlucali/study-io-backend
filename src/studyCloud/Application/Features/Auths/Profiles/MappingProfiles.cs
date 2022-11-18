using Application.Features.Auths.Dtos;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.Features.Auths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RefreshToken, RevokedTokenDto>().ReverseMap();
    }
}