namespace Application.Features.Quizzes.Quiz.Dtos;

public class ListQuizQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryName { get; set; }
    public int SubCategoryName { get; set; }
}