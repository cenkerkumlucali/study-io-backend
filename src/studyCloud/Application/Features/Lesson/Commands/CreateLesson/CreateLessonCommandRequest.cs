using MediatR;

namespace Application.Features.Lesson.Commands.CreateLesson;

public class CreateLessonCommandRequest:IRequest<CreateLessonCommandResponse>
{
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
}