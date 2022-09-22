using Application.Features.Comments.CommentImage.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentImage.Commands.DeleteCommentImage;

public class DeleteCommentImageCommand:IRequest<DeletedCommentImageDto>
{
    public int Id { get; set; }
    public class DeleteCommentImageCommandHandler:IRequestHandler<DeleteCommentImageCommand,DeletedCommentImageDto>
    {
        private ICommentImageRepository _commentImageRepository;
        private IMapper _mapper;

        public DeleteCommentImageCommandHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
        {
            _commentImageRepository = commentImageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCommentImageDto> Handle(DeleteCommentImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentImage commentImage = _mapper.Map<Domain.Entities.Comments.CommentImage>(request);
            Domain.Entities.Comments.CommentImage deletedCommentImage =
                await _commentImageRepository.DeleteAsync(commentImage);
            DeletedCommentImageDto deletedCommentImageDto =
                _mapper.Map<DeletedCommentImageDto>(deletedCommentImage);
            return deletedCommentImageDto;
        }
    }
}