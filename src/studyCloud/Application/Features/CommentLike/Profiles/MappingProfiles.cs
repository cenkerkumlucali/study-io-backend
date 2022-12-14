using Application.Abstractions.Services.Paging;
using Application.Features.CommentLike.Commands.LikeComment;
using Application.Features.CommentLike.Commands.UnLikeComment;
using Application.Features.CommentLike.Models;
using Application.Features.CommentLike.Queries.GetByIdCommentLike;
using Application.Features.CommentLike.Queries.GetListCommentLike;
using Application.Features.CommentLike.Queries.GetUsersLikedComment;
using AutoMapper;

namespace Application.Features.CommentLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.CommentLike, LikeCommentCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, LikeCommentCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UnLikeCommentCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UnLikeCommentCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Comments.CommentLike>,CommentLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike,ListCommentLikeQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Comments.CommentLike, GetByIdCommentLikeQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike,GetUsersLikedCommentQueryRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike,GetUsersLikedCommentQueryResponse>()  
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForMember(c => c.Username, c => c.MapFrom(c => c.User.UserName))
            .ForMember(c => c.UserId, c => c.MapFrom(c => c.User.Id))
            .ForMember(c => c.PictureUrl, c => c.MapFrom(c => c.User.UserImageFiles.FirstOrDefault().Url))
            .ReverseMap();
    }
}