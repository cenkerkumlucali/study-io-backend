using Application.Abstractions.Services.Paging;
using Application.Features.Comment.Commands.CreateComment;
using Application.Features.Comment.Commands.DeleteComment;
using Application.Features.Comment.Commands.UpdateComment;
using Application.Features.Comment.Models;
using Application.Features.Comment.Queries.GetByIdComment;
using Application.Features.Comment.Queries.GetByPostIdComment;
using Application.Features.Comment.Queries.GetListComment;
using Application.Features.Post.Dtos;
using AutoMapper;

namespace Application.Features.Comment.Profiles;

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
            .ForMember(c => c.Children, c => c.MapFrom(c => c.Children))
            .ForMember(c => c.LikeCount, c => c.MapFrom(c => c.CommentLikes.Count))
            .ForMember(c => c.CommentCount, c => c.MapFrom(c => c.Children.Count))
            .ForMember(c => c.Urls, c => c.MapFrom(c => c.CommentImageFiles.Select(c=>c.Url)))
            .ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, ListCommentQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Comments.Comment>, CommentListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, GetByIdCommentQueryResponse>().ReverseMap();
        
        CreateMap<Domain.Entities.Comments.Comment, GetByPostIdCommentQueryRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, GetByPostIdCommentQueryResponse>().ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForMember(c => c.Replies, c => c.MapFrom(c => c.Children))
            .ForMember(c => c.CommentLike, c => c.MapFrom(c => c.CommentLikes.Count))
            .ForMember(c => c.CommentCount, c => c.MapFrom(c => c.Children.Count))
            .ForMember(c => c.Urls, c => c.MapFrom(c => c.CommentImageFiles.Select(c=>c.Url)))
            .ReverseMap();
    }
}