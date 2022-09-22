using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.CommentImage.Commands.CreateCommentImage;
using Application.Features.Comments.CommentImage.Commands.DeleteCommentImage;
using Application.Features.Comments.CommentImage.Commands.UpdateCommentImage;
using Application.Features.Comments.CommentImage.Dtos;
using Application.Features.Comments.CommentImage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Comments.CommentImage.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.Comment, CreatedCommentImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage, CreateCommentImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage, DeletedCommentImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage, DeleteCommentImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage, UpdatedCommentImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage, UpdateCommentImageCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Comments.CommentImage>,CommentImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImage,ListCommentImageDto>().ReverseMap();

        CreateMap<Domain.Entities.Comments.CommentImage, GetByIdCommentImageDto>().ReverseMap();
    }
}