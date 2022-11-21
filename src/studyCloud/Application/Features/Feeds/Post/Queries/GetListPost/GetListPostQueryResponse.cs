namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQueryResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Content { get; set; }
    public string FilePath { get; set; }//TODO liste olarak resimleri veya dosyaları çek
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}