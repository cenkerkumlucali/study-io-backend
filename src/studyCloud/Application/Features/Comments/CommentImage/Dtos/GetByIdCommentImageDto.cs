namespace Application.Features.Comments.CommentImage.Dtos;

public class GetByIdCommentImageDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public int Content { get; set; }
    public string ImagePath { get; set; }
}