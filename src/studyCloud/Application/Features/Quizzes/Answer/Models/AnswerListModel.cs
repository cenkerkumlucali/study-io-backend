using Application.DTOs.Paging;
using Application.Features.Quizzes.Answer.Queries.GetListAnswer;

namespace Application.Features.Quizzes.Answer.Models;

public class AnswerListModel:BasePageableModel
{
    public IList<ListAnswerQueryResponse> Items { get; set; }
}