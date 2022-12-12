using MediatR;

namespace Application.Features.LessonSubject.Commands.DeleteLessonSubject;

public class DeleteLessonSubjectCommandRequest:IRequest<DeleteLessonSubjectCommandResponse>
{
    public long Id { get; set; }
}