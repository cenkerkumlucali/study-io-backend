using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Quiz.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Quiz.Models;

public class QuizListModel:BasePageableModel
{
    public IList<ListQuizDto> Items { get; set; }
}