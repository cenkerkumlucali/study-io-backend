using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.Post.Models;
using AutoMapper;

namespace Application.Features.Feeds.Post.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Domain.Entities.Feeds.Post, CreatePostCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, CreatePostCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, DeletePostCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, DeletePostCommandRequest>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, UpdatePostCommandResponse>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, UpdatePostCommandRequest>().ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Feeds.Post>, PostListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, ListPostQueryResponse>()
            .ForMember(c => c.UserEmail, c => c.MapFrom(c => c.User.Email)).ReverseMap();

        CreateMap<Domain.Entities.Feeds.Post, GetByIdPostQueryResponse>().ReverseMap();
    }
}