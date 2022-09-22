using Application.Features.Feeds.PostImage.Commands.CreatePostImage;
using Application.Features.Feeds.PostImage.Commands.DeletePostImage;
using Application.Features.Feeds.PostImage.Commands.UpdatePostImage;
using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Feeds.PostImage.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.PostImage.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.PostImage, CreatedPostImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, CreatePostImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, DeletedPostImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, DeletePostImageCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, UpdatedPostImageDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage, UpdatePostImageCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.PostImage>,PostImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.PostImage,ListPostImageDto>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.PostImage, GetByIdPostImageDto>().ReverseMap();
    }
}