using Application.DTOs.Paging;
using Application.Features.Answer.Queries.GetListAnswer;

namespace Application.Features.Answer.Models;

public class AnswerListModel:BasePageableModel
{
    public IList<ListAnswerQueryResponse> Items { get; set; }
}