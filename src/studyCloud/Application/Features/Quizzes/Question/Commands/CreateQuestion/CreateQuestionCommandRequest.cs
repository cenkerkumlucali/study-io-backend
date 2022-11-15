using Application.Features.Quizzes.Question.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
{
    public int QuizId { get; set; }
    public string Text { get; set; }

   
}