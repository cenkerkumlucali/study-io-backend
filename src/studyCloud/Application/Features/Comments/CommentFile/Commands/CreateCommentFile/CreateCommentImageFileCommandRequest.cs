using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentImageFileCommandRequest:IRequest<CreateCommentImageFileCommandResponse>
{
    public long Id { get; set; }
    public IFormFileCollection? Files { get; set; }
}