using MediatR;

namespace Application.Features.Lessons.LessonSubject.Commands.CreateLessonSubject;

public class CreateLessonSubjectCommandRequest:IRequest<CreateLessonSubjectCommandResponse>
{
    public string Name { get; set; }
    public int LessonId { get; set; }
    public int? ParentId { get; set; }
}