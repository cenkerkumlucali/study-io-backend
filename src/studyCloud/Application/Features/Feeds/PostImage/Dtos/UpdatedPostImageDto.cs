namespace Application.Features.Feeds.PostImage.Dtos;

public class UpdatedPostImageDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}