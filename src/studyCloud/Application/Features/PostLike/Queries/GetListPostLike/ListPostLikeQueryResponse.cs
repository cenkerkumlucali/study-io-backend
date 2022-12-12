namespace Application.Features.PostLike.Queries.GetListPostLike;

public class ListPostLikeQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}