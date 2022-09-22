using Application.Features.Comments.Comment.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Commands.CreateComment;

public class CreateCommentCommand:IRequest<CreatedCommentDto>
{
    public int UserId { get; set; }
    public int? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommand,CreatedCommentDto>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;


        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.Comment mappedComment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
            Domain.Entities.Comments.Comment createdComment = await _commentRepository.AddAsync(mappedComment);
            CreatedCommentDto mappedCreateCommentDto = _mapper.Map<CreatedCommentDto>(createdComment);
            return mappedCreateCommentDto;
        }
    }
}