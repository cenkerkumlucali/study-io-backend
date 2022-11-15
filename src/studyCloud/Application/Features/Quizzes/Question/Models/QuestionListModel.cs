using Application.DTOs.Paging;
using Application.Features.Quizzes.Question.Dtos;

namespace Application.Features.Quizzes.Question.Models;

public class QuestionListModel:BasePageableModel
{
    public IList<ListQuestionQueryResponse> Items { get; set; }
}