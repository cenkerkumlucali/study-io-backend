namespace Application.Features.Feeds.PostImage.Dtos;

public class ListPostImageDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}