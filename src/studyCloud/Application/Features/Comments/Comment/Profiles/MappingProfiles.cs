using Application.Abstractions.Services.Paging;
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

        CreateMap<IPaginate<Domain.Entities.Comments.Comment>, CommentListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, ListCommentQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, GetByIdCommentQueryResponse>().ReverseMap();
    }
}