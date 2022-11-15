namespace Application.Features.Feeds.PostImage.Dtos;

public class ListPostFileQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}