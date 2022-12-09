using Application.Abstractions.Services;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Application.Repositories.Services.Quizzes;
using Domain.Entities.ImageFile;
using Domain.Entities.Quizzes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class QuestionImageManager : IQuestionImageService
{
    private readonly IQuestionImageRepository _questionImageRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;

    public QuestionImageManager(IQuestionImageRepository questionImageRepository, IQuestionRepository questionRepository, IAwsStorage awsStorage, IStorageService storageService)
    {
        _questionImageRepository = questionImageRepository;
        _questionRepository = questionRepository;
        _awsStorage = awsStorage;
        _storageService = storageService;
    }

    public async Task Upload(long imageId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-question-image", files);
        Question? question = await _questionRepository.GetAsync(c => c.Id == imageId);
        await _questionImageRepository.AddRangeAsync(result.Select(r => new QuestionImage
        {
            FileName = r.fileName,  
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-question-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Questions = new List<Question>() { question }
        }).ToList());
    }
    public async Task<List<QuestionImage>> GetAll()
    {
        return await _questionImageRepository.GetAllAsync();
    }
    
    public async Task<List<QuestionImage>> GetById(int id)
    {
        Question question = await _questionRepository.GetAsync(c => c.Id == id,
            include:c=>c.Include(c=>c.QuestionImages));
        return question.QuestionImages.ToList();
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        return await _awsStorage.GetAllFilesAsync(bucketName, prefix);
    }
}