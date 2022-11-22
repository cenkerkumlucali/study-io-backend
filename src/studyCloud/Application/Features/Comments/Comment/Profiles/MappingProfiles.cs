using Application.Abstractions.Services.Paging;
using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.Comment.Queries.GetByIdComment;
using Application.Features.Comments.Comment.Queries.GetListComment;
using Application.Features.Feeds.Post.Dtos;
using AutoMapper;

namespace Application.Features.Comments.Comment.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.Comment, CreateCommentCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, CreateCommentCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, DeleteCommentCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, DeleteCommentCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, UpdateCommentCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, UpdateCommentCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, PostCommentDto>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForMember(c => c.Childrens, c => c.MapFrom(c => c.Childrens))
            .ForMember(c => c.LikeCount, c => c.MapFrom(c => c.CommentLikes.Count))
            .ForMember(c => c.CommentCount, c => c.MapFrom(c => c.Childrens.Count))
            .ForMember(c => c.Urls, c => c.MapFrom(c => c.CommentImageFiles.Select(c=>c.Url)))
            .ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, ListCommentQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Comments.Comment>, CommentListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, GetByIdCommentQueryResponse>().ReverseMap();
    }
}