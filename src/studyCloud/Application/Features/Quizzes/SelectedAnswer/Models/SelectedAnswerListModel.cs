using Application.DTOs.Paging;
using Application.Features.Quizzes.SelectedAnswer.Dtos;

namespace Application.Features.Quizzes.SelectedAnswer.Models;

public class SelectedAnswerListModel : BasePageableModel
{
    public IList<ListSelectedAnswerQueryResponse> Items { get; set; }
}