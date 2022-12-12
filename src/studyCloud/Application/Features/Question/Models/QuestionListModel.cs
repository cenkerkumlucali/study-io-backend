using Application.DTOs.Paging;
using Application.Features.Question.Queries.GetListQuestion;

namespace Application.Features.Question.Models;

public class QuestionListModel:BasePageableModel
{
    public IList<ListQuestionQueryResponse> Items { get; set; }
}