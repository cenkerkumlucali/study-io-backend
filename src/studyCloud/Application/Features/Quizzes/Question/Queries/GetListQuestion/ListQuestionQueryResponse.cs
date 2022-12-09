namespace Application.Features.Quizzes.Question.Queries.GetListQuestion;

public class ListQuestionQueryResponse
{
    public long Id { get; set; }
    public long QuizId { get; set; }
    public string Text { get; set; }
    public List<Domain.Entities.Quizzes.Answer> Answers { get; set; }
}