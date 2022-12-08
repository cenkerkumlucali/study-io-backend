namespace Domain.Entities.Quizzes;

public class QuestionImage : File
{
    public ICollection<Question> Questions { get; set; }
}