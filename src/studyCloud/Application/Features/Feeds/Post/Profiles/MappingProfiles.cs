using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.Post.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.Post.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.Post, CreatedPostDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, CreatePostCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, DeletedPostDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, DeletePostCommand>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, UpdatedPostDto>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, UpdatePostCommand>().ReverseMap();
        
        CreateMap<IPaginate<Domain.Entities.Feeds.Post>,PostListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post,ListPostDto>().ReverseMap();

        CreateMap<Domain.Entities.Feeds.Post, GetByIdPostDto>().ReverseMap();
    }
}