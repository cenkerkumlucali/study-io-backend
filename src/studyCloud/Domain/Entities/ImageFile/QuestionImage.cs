using Domain.Entities.Quizzes;

namespace Domain.Entities.ImageFile;

public class QuestionImage : File
{
    public ICollection<Question> Questions { get; set; }
}