namespace Application.Features.FlashCard.Commands.UpdateFlashCard;

public class UpdateFlashCardCommandResponse
{
    public string Title { get; set; }
    public string Content { get; set; }
    public long LessonSubjectId { get; set; }
}