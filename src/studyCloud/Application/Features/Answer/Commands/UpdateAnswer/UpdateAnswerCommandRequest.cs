using MediatR;

namespace Application.Features.Answer.Commands.UpdateAnswer;

public class UpdateAnswerCommandRequest : IRequest<UpdatedAnswerCommandResponse>
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

   
}