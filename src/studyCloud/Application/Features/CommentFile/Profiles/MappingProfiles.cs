using Application.Features.CommentFile.Commands.CreateCommentFile;
using Application.Features.CommentFile.Commands.DeleteCommentFile;
using Application.Features.CommentFile.Commands.UpdateCommentFile;
using Application.Features.CommentFile.Queries.GetByIdCommentFile;
using Application.Features.CommentFile.Queries.GetListCommentFile;
using AutoMapper;
using Domain.Entities.ImageFile;

namespace Application.Features.CommentFile.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Comments.Comment, CreateCommentImageFileCommandResponse>().ReverseMap();
        
        CreateMap<CommentImageFile, CreateCommentImageFileCommandRequest>().ReverseMap();
        CreateMap<CommentImageFile, DeleteCommentFileCommandResponse>().ReverseMap();
        CreateMap<CommentImageFile, DeleteCommentFileCommandRequest>().ReverseMap();
        CreateMap<CommentImageFile, UpdateCommentFileCommandResponse>().ReverseMap();
        CreateMap<CommentImageFile, UpdateCommentFileCommandRequest>().ReverseMap();
        CreateMap<CommentImageFile,ListCommentFileQueryResponse>().ReverseMap();
        CreateMap<CommentImageFile, GetByIdCommentFileQueryResponse>().ReverseMap();
        
       
    }
}