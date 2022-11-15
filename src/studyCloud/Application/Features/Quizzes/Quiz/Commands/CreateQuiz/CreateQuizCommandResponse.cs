namespace Application.Features.Quizzes.Quiz.Dtos;

public class CreateQuizCommandResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }
}