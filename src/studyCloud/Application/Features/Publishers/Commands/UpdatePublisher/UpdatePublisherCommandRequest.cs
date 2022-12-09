using MediatR;

namespace Application.Features.Publishers.Commands.UpdatePublisher;

public class UpdatePublisherCommandRequest:IRequest<UpdatePublisherCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
}