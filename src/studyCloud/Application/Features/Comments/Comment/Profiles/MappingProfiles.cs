using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.Comment.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Comments.Comment.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.Comment, CreatedCommentDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, CreateCommentCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, DeletedCommentDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, DeleteCommentCommand>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, UpdatedCommentDto>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, UpdateCommentCommand>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Comments.Comment>, CommentListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.Comment, ListCommentDto>()
            .ForMember(c => c.UserEmail, c => c.MapFrom(c => c.User.Email)).ReverseMap();

        CreateMap<Domain.Entities.Comments.Comment, GetByIdCommentDto>().ReverseMap();
    }
}