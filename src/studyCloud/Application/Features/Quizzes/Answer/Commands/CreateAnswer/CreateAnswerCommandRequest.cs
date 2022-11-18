using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.CreateAnswer;

public class CreateAnswerCommandRequest : IRequest<CreateAnswerCommandResponse>
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    
}