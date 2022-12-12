
namespace Application.Features.Quiz.Queries.GetListQuiz;

public class ListQuizQueryResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string LessonName { get; set; }
    public string SubCategoryName { get; set; }
    public string CategoryName { get; set; }
    public int QuestionCount { get; set; }
    public object Difficulty { get; set; }  
}