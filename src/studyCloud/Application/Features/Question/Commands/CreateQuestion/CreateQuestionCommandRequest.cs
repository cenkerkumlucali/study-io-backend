using Application.Features.Answer.Dtos;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Question.Commands.CreateQuestion;

public class CreateQuestionCommandRequest : IRequest<CreateQuestionCommandResponse>
{
    public long QuizId { get; set; }
    public Difficulty Difficulty { get; set; }
    public IFormFileCollection? Files { get; set; }
    public List<AnswerDto>? CreateAnswerDtos { get; set; }
}