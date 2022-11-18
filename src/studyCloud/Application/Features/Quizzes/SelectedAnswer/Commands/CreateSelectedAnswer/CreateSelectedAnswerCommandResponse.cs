namespace Application.Features.Quizzes.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }
}