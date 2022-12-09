using Application.Abstractions.Services;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Application.Repositories.Services.Feeds;
using Application.Repositories.Services.Files;
using Domain.Entities.Feeds;
using Domain.Entities.ImageFile;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class PostImageFileManager : IPostImageFileService
{
    private readonly IPostImageFileRepository _postImageFileRepository;
    private readonly IFileRepository _fileRepository;
    private readonly IPostRepository _postRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;

    public PostImageFileManager(IPostImageFileRepository postImageFileRepository, IStorageService storageService,
        IPostRepository postRepository, IAwsStorage awsStorage, IFileRepository fileRepository)
    {
        _postImageFileRepository = postImageFileRepository;
        _storageService = storageService;
        _postRepository = postRepository;
        _awsStorage = awsStorage;
        _fileRepository = fileRepository;
    }

    public async Task Upload(long commentId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-post-image", files);
        Post? post = await _postRepository.GetAsync(c => c.Id == commentId);
        await _postImageFileRepository.AddRangeAsync(result.Select(r => new PostImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-post-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Posts = new List<Post>() { post }
        }).ToList());
    }

    public async Task<List<PostImageFile>> GetAll()
    {
        return await _postImageFileRepository.GetAllAsync();
    }

    public async Task<List<PostImageFile>> GetById(int commentId)
    {
        Post post = await _postRepository.GetAsync(c => c.Id == commentId,
            include: c => c.Include(c => c.PostImageFiles));
        return post.PostImageFiles.ToList();
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        return await _awsStorage.GetAllFilesAsync(bucketName, prefix);
    }

    public async Task DeleteAllInPost(Post post)
    {
        IList<PostImageFile> postImages = (await _postImageFileRepository.GetListAsync(c => c.Posts.Contains(post))).Items;
        await _postImageFileRepository.DeleteRangeAsync(postImages);
    }
}