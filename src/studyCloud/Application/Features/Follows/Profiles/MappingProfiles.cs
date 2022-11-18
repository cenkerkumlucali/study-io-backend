using Application.Abstractions.Services.Paging;
using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Commands.DeleteFollow;
using Application.Features.Follows.Commands.UpdateFollow;
using Application.Features.Follows.Models;
using Application.Features.Follows.Queries.GetByIdFollow;
using Application.Features.Follows.Queries.GetListFollow;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Follows.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Follow, CreateFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, CreateFollowCommandRequest>().ReverseMap();
        CreateMap<Follow, DeleteFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, DeleteFollowCommandRequest>().ReverseMap();
        CreateMap<Follow, UpdateFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, UpdateFollowCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Follow>,FollowListModel>().ReverseMap();
        CreateMap<Follow,ListFollowQueryResponse>().ReverseMap();

        CreateMap<Follow, GetByIdFollowQueryResponse>().ReverseMap();
    }
}