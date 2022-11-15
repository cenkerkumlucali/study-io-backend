using Application.Abstractions.Services.Paging;
using Application.Features.Comments.CommentLike.Commands.CreateCommentLike;
using Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;
using Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Features.Comments.CommentLike.Models;
using AutoMapper;

namespace Application.Features.Comments.CommentLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.CommentLike, CreateCommentLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, CreateCommentLikeCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, DeleteCommentLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, DeleteCommentLikeCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UpdateCommentLikeCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UpdateCommentLikeCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Comments.CommentLike>,CommentLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike,ListCommentLikeQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Comments.CommentLike, GetByIdCommentLikeQueryResponse>().ReverseMap();
    }
}