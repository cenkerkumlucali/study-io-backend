using Application.Abstractions.Services;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Application.Repositories.Services.Comments;
using Domain.Entities.Comments;
using Domain.Entities.ImageFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class CommentImageFileManager:ICommentImageFileService
{
    private readonly ICommentImageFileRepository _commentImageFileRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;

    public CommentImageFileManager(ICommentImageFileRepository commentImageFileRepository, IStorageService storageService, ICommentRepository commentRepository, IAwsStorage awsStorage)
    {
        _commentImageFileRepository = commentImageFileRepository;
        _storageService = storageService;
        _commentRepository = commentRepository;
        _awsStorage = awsStorage;
    }

    public async Task Upload(long commentId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-comment-image", files);
        Domain.Entities.Comments.Comment? comment = await _commentRepository.GetAsync(c => c.Id == commentId);
        await _commentImageFileRepository.AddRangeAsync(result.Select(r => new CommentImageFile
        {
            FileName = r.fileName,  
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-comment-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Comments = new List<Domain.Entities.Comments.Comment>() { comment }
        }).ToList());
    }

    public async Task<List<CommentImageFile>> GetAll()
    {
        return await _commentImageFileRepository.GetAllAsync();
    }

    public async Task<List<CommentImageFile>> GetById(int commentId)
    {
        Comment comment = await _commentRepository.GetAsync(c => c.Id == commentId,
            include:c=>c.Include(c=>c.CommentImageFiles));
        return comment.CommentImageFiles.ToList();
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        return await _awsStorage.GetAllFilesAsync(bucketName, prefix);
    }
}