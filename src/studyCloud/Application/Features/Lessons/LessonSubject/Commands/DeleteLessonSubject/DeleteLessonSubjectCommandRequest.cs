using MediatR;

namespace Application.Features.Lessons.LessonSubject.Commands.DeleteLessonSubject;

public class DeleteLessonSubjectCommandRequest:IRequest<DeleteLessonSubjectCommandResponse>
{
    public int Id { get; set; }
}