using Application.Abstractions.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Publishers.Commands.CreatePublisher;

public class CreatePublisherCommandHandler:IRequestHandler<CreatePublisherCommandRequest,CreatePublisherCommandResponse>
{
    private readonly IPublisherService _publisherService;
    private IMapper _mapper;

    public CreatePublisherCommandHandler(IPublisherService publisherService, IMapper mapper)
    {
        _publisherService = publisherService;
        _mapper = mapper;
    }

    public async Task<CreatePublisherCommandResponse> Handle(CreatePublisherCommandRequest request, CancellationToken cancellationToken)
    {
        Publisher? mappedPublisher = _mapper.Map<Publisher>(request);
        Publisher createdPublisher = await _publisherService.AddAsync(mappedPublisher, request.Files);
        CreatePublisherCommandResponse? mappedCreatedPublisher = _mapper.Map<CreatePublisherCommandResponse>(createdPublisher);
        return mappedCreatedPublisher;
    }
}