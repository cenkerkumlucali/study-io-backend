using Application.DTOs.Paging;
using Application.Features.QuizHistory.Queries.GetListQuizHistory;

namespace Application.Features.QuizHistory.Models;

public class QuizHistoryListModel:BasePageableModel
{
    public IList<ListQuizHistoryQueryResponse> Items { get; set; }
}