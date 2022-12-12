using MediatR;

namespace Application.Features.LessonSubject.Commands.UpdateLessonSubject;

public class UpdateLessonSubjectCommandRequest:IRequest<UpdateLessonSubjectCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long LessonId { get; set; }
    public long? ParentId { get; set; }
}