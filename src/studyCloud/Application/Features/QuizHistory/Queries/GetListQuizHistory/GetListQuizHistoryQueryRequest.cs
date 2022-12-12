using Application.Features.QuizHistory.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.QuizHistory.Queries.GetListQuizHistory;

public class GetListQuizHistoryQueryRequest : IRequest<QuizHistoryListModel>
{
    public PageRequest PageRequest { get; set; }

    
}