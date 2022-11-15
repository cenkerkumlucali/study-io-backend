using Application.DTOs.Paging;
using Application.Features.Quizzes.Quiz.Dtos;

namespace Application.Features.Quizzes.Quiz.Models;

public class QuizListModel:BasePageableModel
{
    public IList<ListQuizQueryResponse> Items { get; set; }
}