using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.UpdateSelectedAnswer;

public class UpdateSelectedAnswerCommandRequest : IRequest<UpdateSelectedAnswerCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }

   
}