using MediatR;

namespace Application.Features.Lessons.Lesson.Commands.UpdateLesson;

public class UpdateLessonCommandRequest:IRequest<UpdateLessonCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SubCategoryId { get; set; }
}