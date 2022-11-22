using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostImageFile.Commands.CreatePostImage;
using Application.Features.Feeds.PostImageFile.Commands.DeletePostImage;
using Application.Features.Feeds.PostImageFile.Commands.UpdatePostImage;
using Application.Features.Feeds.PostImageFile.Models;
using Application.Features.Feeds.PostImageFile.Queries.GetByIdPostImage;
using Application.Features.Feeds.PostImageFile.Queries.GetListPostImage;
using AutoMapper;

namespace Application.Features.Feeds.PostImageFile.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostImageFile, CreatePostImageFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, CreatePostImageFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, DeletePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, DeletePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, UpdatePostImageFileQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, UpdatePostImageCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostImageFile>,PostImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile,ListPostImageFileQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostImageFile, GetByIdPostFileQueryResponse>().ReverseMap();
    }
}