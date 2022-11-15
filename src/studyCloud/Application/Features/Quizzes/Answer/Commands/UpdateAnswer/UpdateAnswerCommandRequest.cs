using Application.Features.Quizzes.Answer.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.UpdateAnswer;

public class UpdateAnswerCommandRequest : IRequest<UpdatedAnswerCommandResponse>
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

   
}