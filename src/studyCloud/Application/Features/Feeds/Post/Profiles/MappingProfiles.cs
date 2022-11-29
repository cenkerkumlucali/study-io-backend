using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.Post.Queries.GetByIdPost;
using Application.Features.Feeds.Post.Queries.GetListByUserId;
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
       
        
        CreateMap<PostUploadDto, CreatePostCommandResponse>()
            .ForMember(c => c.UserId, c => c.MapFrom(c => c.Post.UserId))
            .ForMember(c => c.Content, c => c.MapFrom(c => c.Post.Content))
            // .ForMember(c => c.Files, c => c.MapFrom(c => c.Post.PostImageFiles))
            .ReverseMap();

        CreateMap<Domain.Entities.Feeds.Post, GetListPostQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForPath(c => c.CommentCount, opt => opt.MapFrom(c => c.Comments.Count))
            .ReverseMap();

        CreateMap<IPaginate<Domain.Entities.Feeds.Post>, PostListModel>().ReverseMap();
        CreateMap<Domain.Entities.Feeds.Post, GetByIdPostQueryResponse>()
            .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            .ForPath(c => c.Comments, opt => opt.MapFrom(c => c.Comments))
            .ForPath(c => c.CommentCount, opt => opt.MapFrom(c => c.Comments.Count))
            .ForPath(c => c.PostLike, opt => opt.MapFrom(c => c.PostLikes.Count))
            .ForPath(c => c.Urls, opt => opt.MapFrom(c => c.PostImageFiles.Select(c=>c.Url)))
            .ForPath(c => c.ProfileImageUrl, opt => opt.MapFrom(c => c.User.UserImageFiles.FirstOrDefault().Url))
            .ReverseMap();
        
        // CreateMap<IPaginate<Domain.Entities.Feeds.Post>, PostListModel>().ReverseMap();
        // CreateMap<Domain.Entities.Feeds.Post, GetListByUserIdQueryResponse>()
            // .ForMember(c => c.FullName, c => c.MapFrom(c => c.User.FirstName + " " + c.User.LastName))
            // .ForPath(c => c.CommentCount, opt => opt.MapFrom(c => c.Comments.Count))
            // .ForPath(c => c.PostLikes, opt => opt.MapFrom(c => c.PostLikes.Count))
            // .ForPath(c => c.FilePath, opt => opt.MapFrom(c => c.PostImageFiles.Select(c=>c.Url)))
            // .ForPath(c => c.PictureUrl, opt => opt.MapFrom(c => c.User.UserImageFiles.FirstOrDefault().Url))
            // .ReverseMap();
    }
}