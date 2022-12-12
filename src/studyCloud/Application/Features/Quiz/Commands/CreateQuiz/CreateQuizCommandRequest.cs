using MediatR;

namespace Application.Features.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandRequest : IRequest<CreateQuizCommandResponse>
{
    public string Name { get; set; }
    public long PublisherId { get; set; }
    public long? LessonId { get; set; }
    public long? SubCategoryId { get; set; }
    public long? LessonSubjectId { get; set; }
}