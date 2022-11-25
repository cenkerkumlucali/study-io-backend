using Application.Abstractions.Services.Paging;
using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Commands.DeleteFollower;
using Application.Features.Follows.Commands.UnFollow;
using Application.Features.Follows.Commands.UpdateFollow;
using Application.Features.Follows.Dtos;
using Application.Features.Follows.Models;
using Application.Features.Follows.Queries.GetByIdFollow;
using Application.Features.Follows.Queries.GetFollowers;
using Application.Features.Follows.Queries.GetFollowings;
using Application.Features.Follows.Queries.GetListFollow;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Follows.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Follow, CreateFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, CreateFollowCommandRequest>().ReverseMap();
        CreateMap<Follow, UnFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, UnFollowCommandRequest>().ReverseMap();
        CreateMap<Follow, DeleteFollowerCommandResponse>().ReverseMap();
        CreateMap<Follow, DeleteFollowerCommandRequest>().ReverseMap();
        CreateMap<Follow, UpdateFollowCommandResponse>().ReverseMap();
        CreateMap<Follow, UpdateFollowCommandRequest>().ReverseMap();

        CreateMap<FollowerDto, GetFollowersQueryRequest>();
        CreateMap<FollowerDto, GetFollowersQueryResponse>().ReverseMap();
        
        CreateMap<Follow, GetFollowingsQueryRequest>();
        CreateMap<Follow, GetFollowingsQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.Following.FirstName + " " + c.Following.LastName))
            .ForMember(c => c.Username, c => c.MapFrom(c => c.Following.UserName))
            .ForMember(c => c.UserId, c => c.MapFrom(c => c.Following.Id))
            .ForMember(c => c.PictureUrl, c => c.MapFrom(c => c.Following.UserImageFiles.Select(c => c.Url)))
            .ReverseMap();
        
        CreateMap<IPaginate<Follow>, FollowListModel>().ReverseMap();
        CreateMap<Follow, ListFollowQueryResponse>().ReverseMap();

        CreateMap<Follow, GetByIdFollowQueryResponse>().ReverseMap();
    }
}