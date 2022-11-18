using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.Post.Queries.GetByIdPost;
using Application.Features.Feeds.Post.Queries.GetListPost;
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

        CreateMap<Domain.Entities.Feeds.Post, GetListPostQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForPath(c => c.CommentCount, opt=>opt.MapFrom(c=>c.Comments.Count))
            .ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Feeds.Post>, PostListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, GetByIdPostQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForPath(c => c.Comments, opt=>opt.MapFrom(c=>c.Comments))
            .ForPath(c => c.CommentCount, opt=>opt.MapFrom(c=>c.Comments.Count))
            .ReverseMap();
    }
}