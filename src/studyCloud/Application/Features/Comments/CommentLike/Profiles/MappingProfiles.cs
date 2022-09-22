using Application.Features.Comments.CommentLike.Commands.CreateCommentLike;
using Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;
using Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Features.Comments.CommentLike.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Comments.CommentLike.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.CommentLike, CreatedCommentLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, CreateCommentLikeCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, DeletedCommentLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, DeleteCommentLikeCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UpdatedCommentLikeDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike, UpdateCommentLikeCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Comments.CommentLike>,CommentLikeListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentLike,ListCommentLikeDto>().ReverseMap();

        CreateMap<Domain.Entities.Comments.CommentLike, GetByIdCommentLikeDto>().ReverseMap();
    }
}