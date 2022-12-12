using MediatR;

namespace Application.Features.Lesson.Commands.UpdateLesson;

public class UpdateLessonCommandRequest:IRequest<UpdateLessonCommandResponse>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long SubCategoryId { get; set; }
}