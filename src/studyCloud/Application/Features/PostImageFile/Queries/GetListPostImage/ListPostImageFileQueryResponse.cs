namespace Application.Features.PostImageFile.Queries.GetListPostImage;

public class ListPostImageFileQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}