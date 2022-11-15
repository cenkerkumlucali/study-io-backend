using Application.Features.Quizzes.QuizHistory.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetListQuizHistory;

public class GetListQuizHistoryQueryRequest : IRequest<QuizHistoryListModel>
{
    public PageRequest PageRequest { get; set; }

    
}