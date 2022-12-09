using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.UpdateSelectedAnswer;

public class UpdateSelectedAnswerCommandRequest : IRequest<UpdateSelectedAnswerCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuestionId { get; set; }
    public long PossibleAnswerId { get; set; }
    public long QuizHistoryId { get; set; }

   
}