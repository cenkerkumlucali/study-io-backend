using Application.Features.Quizzes.Quiz.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Commands.CreateQuiz;

public class CreateQuizCommandRequest : IRequest<CreateQuizCommandResponse>
{
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int SubCategoryId { get; set; }

    
}