namespace Application.Features.PostImageFile.Commands.UpdatePostImage;

public class UpdatePostImageFileQueryResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}