using Core.Security.Entities;

namespace Application.Features.Comments.CommentImage.Dtos;

public class ListCommentImageDto
{
    public int Id { get; set; }
    public Domain.Entities.Comments.Comment Comment { get; set; }
    public int Content { get; set; }
    public string ImagePath { get; set; }
}