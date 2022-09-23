using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.QuizHistory.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.QuizHistory.Models;

public class QuizHistoryListModel:BasePageableModel
{
    public IList<ListQuizHistoryDto> Items { get; set; }
}