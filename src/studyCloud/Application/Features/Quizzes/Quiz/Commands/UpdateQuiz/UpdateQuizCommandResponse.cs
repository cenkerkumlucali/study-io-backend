namespace Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;

public class UpdateQuizCommandResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
}