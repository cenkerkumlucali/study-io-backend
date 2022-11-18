using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentFileCommandRequest:IRequest<CreateCommentFileCommandResponse>
{
    public string Id { get; set; }
    public IFormFileCollection? Files { get; set; }
}