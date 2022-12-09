namespace Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CategoryName { get; set; }
    public long SubCategoryName { get; set; }
}