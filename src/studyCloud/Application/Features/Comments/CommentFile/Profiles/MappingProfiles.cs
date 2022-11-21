using Application.Abstractions.Services.Paging;
using Application.Features.Comments.CommentFile.Commands.CreateCommentFile;
using Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;
using Application.Features.Comments.CommentFile.Commands.UpdateCommentFile;
using Application.Features.Comments.CommentFile.Models;
using Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;
using Application.Features.Comments.CommentFile.Queries.GetListCommentFile;
using AutoMapper;

namespace Application.Features.Comments.CommentFile.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.Comment, CreateCommentImageFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile, CreateCommentImageFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile, DeleteCommentFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile, DeleteCommentFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile, UpdateCommentFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile, UpdateCommentFileCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Comments.CommentImageFile>,CommentImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Comments.CommentImageFile,ListCommentFileQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Comments.CommentImageFile, GetByIdCommentFileQueryResponse>().ReverseMap();
    }
}