using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostImage.Commands.CreatePostImage;
using Application.Features.Feeds.PostImage.Commands.DeletePostImage;
using Application.Features.Feeds.PostImage.Commands.UpdatePostImage;
using Application.Features.Feeds.PostImage.Models;
using Application.Features.Feeds.PostImage.Queries.GetByIdPostImage;
using Application.Features.Feeds.PostImage.Queries.GetListPostImage;
using AutoMapper;

namespace Application.Features.Feeds.PostImage.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostImageFile, CreatePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, CreatePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, DeletePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, DeletePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, UpdatedPostFileQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile, UpdatePostImageCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostImageFile>,PostImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImageFile,ListPostFileQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostImageFile, GetByIdPostFileQueryResponse>().ReverseMap();
    }
}