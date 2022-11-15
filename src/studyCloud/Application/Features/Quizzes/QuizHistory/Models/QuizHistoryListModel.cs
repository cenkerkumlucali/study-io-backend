using Application.DTOs.Paging;
using Application.Features.Quizzes.QuizHistory.Dtos;

namespace Application.Features.Quizzes.QuizHistory.Models;

public class QuizHistoryListModel:BasePageableModel
{
    public IList<ListQuizHistoryQueryResponse> Items { get; set; }
}