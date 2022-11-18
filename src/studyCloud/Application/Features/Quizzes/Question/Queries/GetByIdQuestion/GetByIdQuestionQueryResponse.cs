namespace Application.Features.Quizzes.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQueryResponse
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }
    public List<Domain.Entities.Quizzes.Answer> Answers { get; set; }

}