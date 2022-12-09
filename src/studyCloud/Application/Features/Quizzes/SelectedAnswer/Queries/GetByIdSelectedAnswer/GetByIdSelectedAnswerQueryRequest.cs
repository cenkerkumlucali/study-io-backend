using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryRequest : IRequest<GetByIdSelectedAnswerQueryResponse>
{
    public long Id { get; set; }
   
}