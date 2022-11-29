using Microsoft.AspNetCore.Http;

namespace Application.Features.Feeds.Post.Dtos;

public class PostUploadDto
{
    public Domain.Entities.Feeds.Post Post { get; set; }
    public IFormFileCollection Files { get; set; }
}