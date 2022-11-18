using Application.DTOs.Paging;
using Application.Features.Quizzes.QuizHistory.Queries.GetListQuizHistory;

namespace Application.Features.Quizzes.QuizHistory.Models;

public class QuizHistoryListModel:BasePageableModel
{
    public IList<ListQuizHistoryQueryResponse> Items { get; set; }
}