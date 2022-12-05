using MediatR;

namespace Application.Features.Lessons.LessonSubject.Commands.UpdateLessonSubject;

public class UpdateLessonSubjectCommandRequest:IRequest<UpdateLessonSubjectCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LessonId { get; set; }
    public int? ParentId { get; set; }
}