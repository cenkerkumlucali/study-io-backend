namespace Application.Features.Question.Commands.CreateQuestion;

public class CreateQuestionCommandResponse
{
    public long Id { get; set; }
    public long QuizId { get; set; }
    public string ImageUrl { get; set; }
}