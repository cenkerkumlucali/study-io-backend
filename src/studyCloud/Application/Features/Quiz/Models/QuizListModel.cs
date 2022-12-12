using Application.DTOs.Paging;
using Application.Features.Quiz.Queries.GetListQuiz;

namespace Application.Features.Quiz.Models;

public class QuizListModel:BasePageableModel
{
    public IList<ListQuizQueryResponse> Items { get; set; }
}