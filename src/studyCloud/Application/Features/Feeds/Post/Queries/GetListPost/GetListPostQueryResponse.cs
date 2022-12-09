namespace Application.Features.Feeds.Post.Queries.GetListPost;

public class GetListPostQueryResponse
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Content { get; set; }
    public string FilesUrl { get; set; }//TODO: pull List images or files
    public int CommentCount { get; set; }
    public DateTime CreatedDate { get; set; }
}