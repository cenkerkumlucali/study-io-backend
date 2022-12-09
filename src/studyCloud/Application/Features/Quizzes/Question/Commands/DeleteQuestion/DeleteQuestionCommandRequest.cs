using MediatR;

namespace Application.Features.Quizzes.Question.Commands.DeleteQuestion;

public class DeleteQuestionCommandRequest:IRequest<DeleteQuestionCommandResponse>
{
    public long Id { get; set; }
 
}