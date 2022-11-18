using Application.DTOs.Paging;
using Application.Features.Quizzes.SelectedAnswer.Queries.GetListSelectedAnswer;

namespace Application.Features.Quizzes.SelectedAnswer.Models;

public class SelectedAnswerListModel : BasePageableModel
{
    public IList<ListSelectedAnswerQueryResponse> Items { get; set; }
}