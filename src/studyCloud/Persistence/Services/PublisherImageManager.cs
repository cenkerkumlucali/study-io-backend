using Application.Abstractions.Services;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Application.Repositories.Services.Files;
using Application.Repositories.Services.Publishers;
using Domain.Entities;
using Domain.Entities.ImageFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class PublisherImageManager : IPublisherImageService
{
    private readonly IPublisherImageRepository _publisherImageRepository;
    private readonly IFileRepository _fileRepository;
    private readonly IPublisherRepository _publisherRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;

    public PublisherImageManager(IPublisherImageRepository publisherImageRepository, IFileRepository fileRepository, IPublisherRepository publisherRepository, IStorageService storageService, IAwsStorage awsStorage)
    {
        _publisherImageRepository = publisherImageRepository;
        _fileRepository = fileRepository;
        _publisherRepository = publisherRepository;
        _storageService = storageService;
        _awsStorage = awsStorage;
    }

    public async Task Upload(long commentId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-publisher-image", files);
        Publisher? post = await _publisherRepository.GetAsync(c => c.Id == commentId);
        await _publisherImageRepository.AddRangeAsync(result.Select(r => new PublisherImage
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-publisher-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Publishers = new List<Publisher>() { post }
        }).ToList());
    }

    public async Task<List<PublisherImage>> GetAll()
    {
        return await _publisherImageRepository.GetAllAsync();
    }

    public async Task<List<PublisherImage>> GetById(int commentId)
    {
        Publisher? post = await _publisherRepository.GetAsync(c => c.Id == commentId,
            include: c => c.Include(c => c.PublisherImages));
        return post.PublisherImages.ToList();
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        return await _awsStorage.GetAllFilesAsync(bucketName, prefix);
    }
}