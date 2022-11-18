using Application.Abstractions.Services.Paging;
using Application.DTOs.Post;
using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.Comment.Queries.GetByIdComment;
using Application.Features.Comments.Comment.Queries.GetListComment;
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
            .ForMember(c => c.CommentId, c => c.MapFrom(c => c.Id))
            .ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, ListCommentQueryResponse>().ReverseMap();
        CreateMap<IPaginate<Domain.Entities.Comments.Comment>, CommentListModel>().ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, GetByIdCommentQueryResponse>().ReverseMap();
    }
}