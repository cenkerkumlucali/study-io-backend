using MediatR;

namespace Application.Features.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryRequest : IRequest<GetByIdSelectedAnswerQueryResponse>
{
    public long Id { get; set; }
   
}