using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Commands.DeleteFollow;
using Application.Features.Follows.Commands.UpdateFollow;
using Application.Features.Follows.Dtos;
using Application.Features.Follows.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities.Follow;

namespace Application.Features.Follows.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Follow, CreatedFollowDto>().ReverseMap();
        CreateMap<Follow, CreateFollowCommand>().ReverseMap();
        CreateMap<Follow, DeletedFollowDto>().ReverseMap();
        CreateMap<Follow, DeleteFollowCommand>().ReverseMap();
        CreateMap<Follow, UpdatedFollowDto>().ReverseMap();
        CreateMap<Follow, UpdateFollowCommand>().ReverseMap();
        
        CreateMap<IPaginate<Follow>,FollowListModel>().ReverseMap();
        CreateMap<Follow,ListFollowDto>().ReverseMap();

        CreateMap<Follow, GetByIdFollowDto>().ReverseMap();
    }
}