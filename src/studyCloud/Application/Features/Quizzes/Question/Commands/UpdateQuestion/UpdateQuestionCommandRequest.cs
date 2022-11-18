using MediatR;

namespace Application.Features.Quizzes.Question.Commands.UpdateQuestion;

public class UpdateQuestionCommandRequest : IRequest<UpdateQuestionCommandResponse>
{
    public int Id { get; set; }
    public int QuizId { get; set; }
    public string Text { get; set; }

   
}