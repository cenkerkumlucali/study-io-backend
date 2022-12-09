using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Commands.DeleteSelectedAnswer;

public class DeleteSelectedAnswerCommandRequest:IRequest<DeleteSelectedAnswerCommandResponse>
{
    public long Id { get; set; }
    
}