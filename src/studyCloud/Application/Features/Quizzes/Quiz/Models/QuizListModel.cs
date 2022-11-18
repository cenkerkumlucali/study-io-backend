using Application.DTOs.Paging;
using Application.Features.Quizzes.Quiz.Queries.GetListQuiz;

namespace Application.Features.Quizzes.Quiz.Models;

public class QuizListModel:BasePageableModel
{
    public IList<ListQuizQueryResponse> Items { get; set; }
}