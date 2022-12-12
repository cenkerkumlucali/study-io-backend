using MediatR;

namespace Application.Features.Question.Commands.DeleteQuestion;

public class DeleteQuestionCommandRequest:IRequest<DeleteQuestionCommandResponse>
{
    public long Id { get; set; }
 
}