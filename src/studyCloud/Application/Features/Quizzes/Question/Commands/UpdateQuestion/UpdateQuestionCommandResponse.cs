namespace Application.Features.Quizzes.Question.Dtos;

public class UpdateQuestionCommandResponse
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }
}