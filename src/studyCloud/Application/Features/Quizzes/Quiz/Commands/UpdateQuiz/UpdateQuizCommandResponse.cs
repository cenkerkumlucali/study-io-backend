namespace Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
}