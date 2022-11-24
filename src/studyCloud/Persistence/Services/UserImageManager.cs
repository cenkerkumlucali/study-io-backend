using Application.Abstractions.Services;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class UserImageManager:IUserImageService
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly IUserRepository _userRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;

    public UserImageManager(IStorageService storageService, IUserRepository userRepository, IUserImageRepository userImageRepository, IAwsStorage awsStorage)
    {
        _storageService = storageService;
        _userRepository = userRepository;
        _userImageRepository = userImageRepository;
        _awsStorage = awsStorage;
    }


    public async Task Upload(int commentId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-user-image", files);
        User? user = await _userRepository.GetAsync(c => c.Id == commentId);
        await _userImageRepository.AddRangeAsync(result.Select(r => new UserImageFile()
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-user-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Users = new List<User>() {user }
        }).ToList());
    }

    public async Task<List<UserImageFile>> GetAll()
    {
        return await _userImageRepository.GetAllAsync();
    }

    public async Task<List<UserImageFile>> GetById(int commentId)
    {
        User post = await _userRepository.GetAsync(c => c.Id == commentId,
            include: c => c.Include(c => c.UserImageFiles));
        return post.UserImageFiles.ToList();
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        return await _awsStorage.GetAllFilesAsync(bucketName, prefix);
    }
}