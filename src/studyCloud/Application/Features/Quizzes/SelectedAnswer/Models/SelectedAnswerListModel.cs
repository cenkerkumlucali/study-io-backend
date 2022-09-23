using Application.Features.Quizzes.SelectedAnswer.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.SelectedAnswer.Models;

public class SelectedAnswerListModel : BasePageableModel
{
    public IList<ListSelectedAnswerDto> Items { get; set; }
}