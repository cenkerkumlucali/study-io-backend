using Application.Repositories.Services.Publishers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommandHandler:IRequestHandler<DeletePublisherCommandRequest,DeletePublisherCommandResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private IMapper _mapper;
    public DeletePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<DeletePublisherCommandResponse> Handle(DeletePublisherCommandRequest request, CancellationToken cancellationToken)
    {
        Publisher? publisher = await _publisherRepository.GetAsync(c => c.Id == request.Id);
        Publisher deletedPublisher = await _publisherRepository.DeleteAsync(publisher);
        DeletePublisherCommandResponse? mappedDeletedPublisher = _mapper.Map<DeletePublisherCommandResponse>(deletedPublisher);
        return mappedDeletedPublisher;
    }
}