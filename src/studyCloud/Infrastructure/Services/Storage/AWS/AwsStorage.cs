using Amazon.S3;
using Amazon.S3.Model;
using Application.Abstractions.Storage.AWS;
using Application.DTOs.Storage.AWS;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services.Storage.AWS;

public class AwsStorage : Storage, IAwsStorage
{
    private IAmazonS3 _amazonS3;
    static private AmazonS3Client s3Client = new AmazonS3Client();

    public AwsStorage(IAmazonS3 amazonS3)
    {
        _amazonS3 = amazonS3;
    }

    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string bucketName,
        IFormFileCollection files)
    {
        bool bucketExists = await _amazonS3.DoesS3BucketExistAsync(bucketName);
        if (!bucketExists)
            throw new Exception($"Bucket {bucketName} does not exist.");
        List<(string fileName, string pathOrContainerName)> datas = new();

        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(bucketName, file.FileName, async (bucketName1, fileName) => await HasFile(bucketName1, fileName));

            PutObjectRequest request = new()
            {
                BucketName = bucketName,
                Key = $"{bucketName}/{fileNewName}",
                InputStream = file.OpenReadStream()
            };
            request.Metadata.Add("Content-Type", file.ContentType);
            datas.Add((fileNewName, $"{bucketName}/{fileNewName}"));
            await _amazonS3.PutObjectAsync(request);
        }

        return datas;
    }

    public async Task DeleteAsync(string bucketName, string fileName)
    {
        bool bucketExists = await _amazonS3.DoesS3BucketExistAsync(bucketName);
        if (!bucketExists)
            throw new Exception($"Bucket {bucketName} does not exist.");
        await _amazonS3.DeleteObjectAsync(bucketName, fileName);
    }

    public async Task<bool> HasFile(string bucketName, string fileName)
    {
        ListObjectsV2Request request = new()
        {
            BucketName = bucketName,
        };
        ListObjectsV2Response response = await _amazonS3.ListObjectsV2Async(request);

        bool result = response.S3Objects.Any(c => c.Key == $"{bucketName}/{fileName}");

        return result;
    }

    public async Task<List<S3ObjectDto>> GetAllFilesAsync(string bucketName, string? prefix)
    {
        bool bucketExists = await _amazonS3.DoesS3BucketExistAsync(bucketName);
        if (!bucketExists)
            throw new Exception($"Bucket {bucketName} does not exist.");
        ListObjectsV2Request request = new()
        {
            BucketName = bucketName,
        };
        ListObjectsV2Response response = await _amazonS3.ListObjectsV2Async(request);
        List<S3ObjectDto> objectDatas = response.S3Objects.Select(@object =>
        {
            GetPreSignedUrlRequest urlRequest = new()
            {
                BucketName = bucketName,
                Key = @object.Key,
                Expires = DateTime.UtcNow.AddMinutes(1)
            };
            return new S3ObjectDto
            {
                Name = @object.Key,
                Url = _amazonS3.GetPreSignedURL(urlRequest)
            };
        }).ToList();
        return objectDatas;
    }

    public List<string> GetFiles(string bucketName)
    {
        throw new NotImplementedException();
    }
}