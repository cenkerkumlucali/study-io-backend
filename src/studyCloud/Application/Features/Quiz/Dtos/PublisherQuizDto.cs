namespace Application.Features.Quiz.Dtos;

public class PublisherQuizDto
{
    public long QuizId { get; set; }
    public string LessonName { get; set; }
    public string SubCategoryName { get; set; }
    public string QuizName { get; set; }
    public object Difficulty { get; set; }
}