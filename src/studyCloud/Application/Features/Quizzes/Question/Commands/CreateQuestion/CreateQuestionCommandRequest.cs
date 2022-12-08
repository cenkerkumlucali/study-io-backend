using Application.Features.Quizzes.Answer.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Quizzes.Question.Commands.CreateQuestion;

public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
{
    public int QuizId { get; set; }
    public IFormFileCollection? Files { get; set; }
    public List<AnswerDto>? CreateAnswerDtos { get; set; }
}