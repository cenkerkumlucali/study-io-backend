namespace Application.Features.Feeds.Post.Dtos;

public class GetByIdPostDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}