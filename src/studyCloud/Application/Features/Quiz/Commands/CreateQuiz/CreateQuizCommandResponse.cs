namespace Application.Features.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandResponse
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
}