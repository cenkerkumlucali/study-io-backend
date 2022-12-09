using Application.Abstractions.Services;
using Application.Repositories.Services.Publishers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Persistence.Services;

public class PublisherManager:IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IPublisherImageService _publisherImageService;

    public PublisherManager(IPublisherRepository publisherRepository, IPublisherImageService publisherImageService)
    {
        _publisherRepository = publisherRepository;
        _publisherImageService = publisherImageService;
    }

    public async Task<Publisher> AddAsync(Publisher publisher, IFormFileCollection files)
    {
        Publisher createdPublisher = await _publisherRepository.AddAsync(publisher);
        await _publisherImageService.Upload(createdPublisher.Id, files);
        return createdPublisher;
    }

    public async Task<Publisher> UpdateAsync(Publisher publisher, IFormFileCollection files)
    {
        Publisher updatedPublisher = await _publisherRepository.UpdateAsync(publisher);
        await _publisherImageService.Upload(updatedPublisher.Id, files);
        return updatedPublisher;
    }
}