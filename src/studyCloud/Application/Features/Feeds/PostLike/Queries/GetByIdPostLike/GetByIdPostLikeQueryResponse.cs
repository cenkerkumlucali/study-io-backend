namespace Application.Features.Feeds.PostLike.Dtos;

public class GetByIdPostLikeQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
}