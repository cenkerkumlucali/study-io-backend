using MediatR;

namespace Application.Features.LessonSubject.Commands.CreateLessonSubject;

public class CreateLessonSubjectCommandRequest:IRequest<CreateLessonSubjectCommandResponse>
{
    public string Name { get; set; }
    public long LessonId { get; set; }
    public long? ParentId { get; set; }
}