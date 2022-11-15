using Application.Features.Quizzes.SelectedAnswer.Dtos;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommandRequest : IRequest<CreateSelectedAnswerCommandResponse>
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }

    
}