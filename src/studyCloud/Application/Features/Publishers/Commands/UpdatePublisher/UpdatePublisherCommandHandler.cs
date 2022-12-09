using Application.Abstractions.Services;
using Application.Repositories.Services.Publishers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Publishers.Commands.UpdatePublisher;

public class
    UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, UpdatePublisherCommandResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IPublisherService _publisherService;
    private IMapper _mapper;

    public UpdatePublisherCommandHandler(IPublisherService publisherService, IMapper mapper,
        IPublisherRepository publisherRepository)
    {
        _publisherService = publisherService;
        _mapper = mapper;
        _publisherRepository = publisherRepository;
    }

    public async Task<UpdatePublisherCommandResponse> Handle(UpdatePublisherCommandRequest request,
        CancellationToken cancellationToken)
    {
        Publisher? publisher = await _publisherRepository.GetAsync(c => c.Id == request.Id);
        Publisher? mappedLesson = _mapper.Map(request, publisher);
        UpdatePublisherCommandResponse? mappedUpdatedLesson = _mapper.Map<UpdatePublisherCommandResponse>(mappedLesson);
        return mappedUpdatedLesson;
    }
}