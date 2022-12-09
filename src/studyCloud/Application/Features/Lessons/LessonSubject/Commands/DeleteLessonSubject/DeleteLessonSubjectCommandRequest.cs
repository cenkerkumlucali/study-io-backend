using MediatR;

namespace Application.Features.Lessons.LessonSubject.Commands.DeleteLessonSubject;

public class DeleteLessonSubjectCommandRequest:IRequest<DeleteLessonSubjectCommandResponse>
{
    public long Id { get; set; }
}