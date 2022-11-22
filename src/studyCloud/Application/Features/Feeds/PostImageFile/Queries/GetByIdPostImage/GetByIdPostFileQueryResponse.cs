namespace Application.Features.Feeds.PostImageFile.Queries.GetByIdPostImage;

public class GetByIdPostFileQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}