using Application.Features.Quizzes.Question.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQueryRequest : IRequest<GetByIdQuestionQueryResponse>
{
    public int Id { get; set; }
    
}