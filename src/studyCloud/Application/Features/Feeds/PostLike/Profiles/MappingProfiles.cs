using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostLike.Commands.CreatePostLike;
using Application.Features.Feeds.PostLike.Commands.DeletePostLike;
using Application.Features.Feeds.PostLike.Commands.UpdatePostLike;
using Application.Features.Feeds.PostLike.Dtos;
using Application.Features.Feeds.PostLike.Models;
using AutoMapper;

namespace Application.Features.Feeds.PostLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostLike, CreatePostLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, CreatePostLikeCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, DeletePostLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, DeletePostLikeCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UpdatePostLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UpdatePostLikeCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostLike>,PostLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike,ListPostLikeQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostLike, GetByIdPostLikeQueryResponse>().ReverseMap();
    }
}