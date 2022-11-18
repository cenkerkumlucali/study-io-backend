namespace Application.Features.Quizzes.Question.Queries.GetListQuestion;

public class ListQuestionQueryResponse
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }
    public List<Domain.Entities.Quizzes.Answer> Answers { get; set; }
}