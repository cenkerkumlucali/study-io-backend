using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Publishers.Commands.CreatePublisher;

public class CreatePublisherCommandRequest:IRequest<CreatePublisherCommandResponse>
{
    public string Name { get; set; }
    public IFormFileCollection Files { get; set; }
}