namespace Application.Features.Quizzes.Question.Dtos;

public class GetByIdQuestionDto
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }
    public List<Domain.Entities.Quizzes.Answer> Answers { get; set; }

}