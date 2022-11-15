using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostImage.Commands.CreatePostImage;
using Application.Features.Feeds.PostImage.Commands.DeletePostImage;
using Application.Features.Feeds.PostImage.Commands.UpdatePostImage;
using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Feeds.PostImage.Models;
using AutoMapper;

namespace Application.Features.Feeds.PostImage.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostImage, CreatePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, CreatePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, DeletePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, DeletePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, UpdatedPostFileQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, UpdatePostImageCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostImage>,PostImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage,ListPostFileQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostImage, GetByIdPostFileQueryResponse>().ReverseMap();
    }
}