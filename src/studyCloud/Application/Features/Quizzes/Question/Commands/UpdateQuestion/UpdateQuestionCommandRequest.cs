using MediatR;

namespace Application.Features.Quizzes.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommandRequest : IRequest<UpdateQuestionCommandResponse>
{
    public long Id { get; set; }
    public long QuizId { get; set; }
    public string Text { get; set; }

   
}