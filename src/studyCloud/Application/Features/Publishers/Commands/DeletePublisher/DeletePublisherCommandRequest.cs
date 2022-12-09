using MediatR;

namespace Application.Features.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommandRequest:IRequest<DeletePublisherCommandResponse>
{
    public long Id { get; set; }
}