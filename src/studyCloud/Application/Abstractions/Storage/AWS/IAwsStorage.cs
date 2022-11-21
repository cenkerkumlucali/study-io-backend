using Application.DTOs.Storage.AWS;

namespace Application.Abstractions.Storage.AWS;

public interface IAwsStorage : IStorage
{
    Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName,string? prefix);
}