using Application.Abstractions.Services;
using Application.Abstractions.Services.ElasticSearch;
using Application.Abstractions.Storage;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.ElasticSearch;
using Application.DTOs.Storage.AWS;
using Application.Features.Users.User.Dtos;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Persistence.Services;

public class UserImageManager:IUserImageService
{
    private readonly IUserImageRepository _userImageRepository;
    private readonly IUserRepository _userRepository;
    private readonly IStorageService _storageService;
    private readonly IAwsStorage _awsStorage;
    private readonly IElasticSearch _elasticSearch;

    public UserImageManager(IStorageService storageService, IUserRepository userRepository, IUserImageRepository userImageRepository, IAwsStorage awsStorage, IElasticSearch elasticSearch)
    {
        _storageService = storageService;
        _userRepository = userRepository;
        _userImageRepository = userImageRepository;
        _awsStorage = awsStorage;
        _elasticSearch = elasticSearch;
    }


    public async Task Upload(int userId, IFormFileCollection files)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-user-image", files);
        User? user = await _userRepository.GetAsync(c => c.Id == userId);
        await _userImageRepository.AddRangeAsync(result.Select(r => new UserImageFile()
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Url = $"http://study.io-user-image.s3.amazonaws.com/{r.pathOrContainerName}",
            Users = new List<User>() {user }
        }).ToList());
        foreach (var value in result)
        {
            List<ElasticSearchGetModel<UserDto>> getUser = await
                _elasticSearch.GetSearchByField<UserDto>(
                    new SearchByFieldParameters
                    {
                        IndexName = "users",
                        FieldName = "UserName",
                        Value = user.UserName
                    });

            ElasticSearchInsertUpdateModel model = new()
            {
                ElasticId = getUser.FirstOrDefault()?.ElasticId,
                IndexName = "users",
                Item = new UserDto()
                {
                    Id = user.Id,
                    FullName = user.FirstName + " " + user.LastName,
                    UserName = user.UserName,
                    PictureUrl = $"http://study.io-user-image.s3.amazonaws.com/{value.pathOrContainerName}"
                }
            };
            await _elasticSearch.UpdateByElasticIdAsync(model);
        }
        
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