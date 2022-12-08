namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommandResponse
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string ImageUrl { get; set; }
}