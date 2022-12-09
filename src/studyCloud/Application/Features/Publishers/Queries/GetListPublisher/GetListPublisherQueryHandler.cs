using Application.Abstractions.Services.Paging;
using Application.Features.Publishers.Models;
using Application.Repositories.Services.Publishers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Publishers.Queries.GetListPublisher;

public class GetListPublisherQueryHandler : IRequestHandler<GetListPublisherQueryRequest, PublisherListModel>
{
    private readonly IPublisherRepository _publisherRepository;
    private IMapper _mapper;

    public GetListPublisherQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<PublisherListModel> Handle(GetListPublisherQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Publisher> publishers = await _publisherRepository.GetListAsync(
            index: request.PageRequest.Page,
            size: request.PageRequest.PageSize,
            include:c=>c.Include(c=>c.PublisherImages));
        PublisherListModel? mappedPublisher = _mapper.Map<PublisherListModel>(publishers);
        return mappedPublisher;
    }
}