using Application.Features.Quizzes.Question.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.DeleteQuestion;

public class DeleteQuestionCommandRequest:IRequest<DeleteQuestionCommandResponse>
{
    public int Id { get; set; }
 
}