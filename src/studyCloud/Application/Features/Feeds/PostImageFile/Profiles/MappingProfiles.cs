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
        CreateMap<Domain.Entities.ImageFile.PostImageFile, CreatePostImageFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile, CreatePostImageFileCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile, DeletePostFileCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile, DeletePostImageCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile, UpdatePostImageFileQueryResponse>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile, UpdatePostImageCommandRequest>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.ImageFile.PostImageFile>,PostImageListModel>().ReverseMap();
        CreateMap<Domain.Entities.ImageFile.PostImageFile,ListPostImageFileQueryResponse>().ReverseMap();

        CreateMap<Domain.Entities.ImageFile.PostImageFile, GetByIdPostFileQueryResponse>().ReverseMap();
    }
}