using Application.Abstractions.Services.Paging;
using Application.Features.PostLike.Commands.LikePost;
using Application.Features.PostLike.Commands.UnLikePost;
using Application.Features.PostLike.Models;
using Application.Features.PostLike.Queries.GetByIdPostLike;
using Application.Features.PostLike.Queries.GetListPostLike;
using Application.Features.PostLike.Queries.GetMembersLikedPost;
using AutoMapper;

namespace Application.Features.PostLike.Profiles;

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