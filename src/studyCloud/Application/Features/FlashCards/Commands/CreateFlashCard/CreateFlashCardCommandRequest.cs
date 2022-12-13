using MediatR;

namespace Application.Features.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommandRequest:IRequest<CreateFlashCardCommandResponse>
{
    public string Title { get; set; }
    public string Content { get; set; }
    public long LessonSubjectId { get; set; }
}