namespace Application.Features.Quizzes.SelectedAnswer.Dtos;

public class GetByIdSelectedAnswerDto
{
    public int Id { get; set; }
    public int UserEmail { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }
}