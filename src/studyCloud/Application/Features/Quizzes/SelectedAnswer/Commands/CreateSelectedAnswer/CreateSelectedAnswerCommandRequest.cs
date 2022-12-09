using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommandRequest : IRequest<CreateSelectedAnswerCommandResponse>
{
    public long UserId { get; set; }
    public long QuestionId { get; set; }
    public long AnswerId { get; set; }
    public long QuizHistoryId { get; set; }
}