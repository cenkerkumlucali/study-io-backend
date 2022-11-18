namespace Application.Features.Feeds.PostLike.Queries.GetListPostLike;

public class ListPostLikeQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}