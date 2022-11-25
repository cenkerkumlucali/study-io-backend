using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostLike.Commands.LikePost;
using Application.Features.Feeds.PostLike.Commands.UnLikePost;
using Application.Features.Feeds.PostLike.Models;
using Application.Features.Feeds.PostLike.Queries.GetByIdPostLike;
using Application.Features.Feeds.PostLike.Queries.GetListPostLike;
using Application.Features.Feeds.PostLike.Queries.GetMembersLikedPost;
using AutoMapper;

namespace Application.Features.Feeds.PostLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostLike, LikePostCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, LikePostCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UnLikePostCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike, UnLikePostCommandRequest>().ReverseMap();
        
        CreateMap<Domain.Entities.Feeds.PostLike,GetMembersLikedPostQueryRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike,GetMembersLikedPostQueryResponse>()  
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForMember(c => c.Username, c => c.MapFrom(c => c.User.UserName))
            .ForMember(c => c.UserId, c => c.MapFrom(c => c.User.Id))
            .ForMember(c => c.PictureUrl, c => c.MapFrom(c => c.User.UserImageFiles.FirstOrDefault().Url))
            .ReverseMap();

        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostLike>,PostLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostLike,ListPostLikeQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostLike, GetByIdPostLikeQueryResponse>().ReverseMap();
    }
}