using Application.DTOs.Storage.AWS;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services;

public interface IImageFileService<T>
{
    Task Upload(long id, IFormFileCollection files);
    Task<List<T>> GetAll();
    Task<List<T>> GetById(int id);
    Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix);
}