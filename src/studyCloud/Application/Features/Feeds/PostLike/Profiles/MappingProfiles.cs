using Application.Features.Feeds.PostLike.Commands.CreatePostLike;
using Application.Features.Feeds.PostLike.Commands.DeletePostLike;
using Application.Features.Feeds.PostLike.Commands.UpdatePostLike;
using Application.Features.Feeds.PostLike.Dtos;
using Application.Features.Feeds.PostLike.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.PostLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostLike, CreatedPostLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, CreatePostLikeCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, DeletedPostLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, DeletePostLikeCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UpdatedPostLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UpdatePostLikeCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostLike>,PostLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike,ListPostLikeDto>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostLike, GetByIdPostLikeDto>().ReverseMap();
    }
}