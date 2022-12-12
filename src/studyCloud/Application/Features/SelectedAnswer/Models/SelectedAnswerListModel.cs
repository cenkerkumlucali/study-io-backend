using Application.DTOs.Paging;
using Application.Features.SelectedAnswer.Queries.GetListSelectedAnswer;

namespace Application.Features.SelectedAnswer.Models;

public class SelectedAnswerListModel : BasePageableModel
{
    public IList<ListSelectedAnswerQueryResponse> Items { get; set; }
}