using MediatR;

namespace Application.Features.Lesson.Commands.DeleteLesson;

public class DeleteLessonCommandRequest:IRequest<DeleteLessonCommandResponse>
{
    public long Id { get; set; }
}