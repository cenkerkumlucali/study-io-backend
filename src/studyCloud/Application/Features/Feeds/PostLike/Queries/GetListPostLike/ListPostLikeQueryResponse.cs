namespace Application.Features.Feeds.PostLike.Dtos;

public class ListPostLikeQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}