using Application.DTOs.Paging;
using Application.Features.Quizzes.Question.Queries.GetListQuestion;

namespace Application.Features.Quizzes.Question.Models;

public class QuestionListModel:BasePageableModel
{
    public IList<ListQuestionQueryResponse> Items { get; set; }
}