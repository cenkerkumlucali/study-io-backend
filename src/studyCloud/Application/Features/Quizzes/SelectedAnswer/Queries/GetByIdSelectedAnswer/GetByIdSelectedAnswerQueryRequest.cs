using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryRequest : IRequest<GetByIdSelectedAnswerQueryResponse>
{
    public int Id { get; set; }
   
}