using Application.Features.Comments.Comment.Models;
using Application.Features.Feeds.Post.Models;
using Application.Services.Repositories.Comments;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQuery : IRequest<PostListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, PostListModel>
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostListModel> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Feeds.Post> post =
                await _postRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            PostListModel mappedPostListModel =
                _mapper.Map<PostListModel>(post);
            return mappedPostListModel;
        }
    }
}