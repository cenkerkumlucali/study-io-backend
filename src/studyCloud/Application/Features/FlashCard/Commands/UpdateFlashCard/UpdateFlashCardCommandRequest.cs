using MediatR;

namespace Application.Features.FlashCard.Commands.UpdateFlashCard;

public class UpdateFlashCardCommandRequest : IRequest<UpdateFlashCardCommandResponse>
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public long LessonSubjectId { get; set; }
}