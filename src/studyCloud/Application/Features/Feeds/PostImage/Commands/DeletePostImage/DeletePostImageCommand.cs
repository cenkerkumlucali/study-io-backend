using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.DeletePostImage;

public class DeletePostImageCommand:IRequest<DeletedPostImageDto>
{
    public int Id { get; set; }
    public class DeletePostImageCommandHandler:IRequestHandler<DeletePostImageCommand,DeletedPostImageDto>
    {
        private IPostImageRepository _postImageRepository;
        private IMapper _mapper;

        public DeletePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedPostImageDto> Handle(DeletePostImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostImage postImage = _mapper.Map<Domain.Entities.Feeds.PostImage>(request);
            Domain.Entities.Feeds.PostImage deletedPostImage =
                await _postImageRepository.DeleteAsync(postImage);
            DeletedPostImageDto deletedPostImageDto =
                _mapper.Map<DeletedPostImageDto>(deletedPostImage);
            return deletedPostImageDto;
        }
    }
}