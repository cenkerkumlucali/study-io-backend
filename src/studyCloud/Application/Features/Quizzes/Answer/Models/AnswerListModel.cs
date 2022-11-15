using Application.DTOs.Paging;
using Application.Features.Quizzes.Answer.Dtos;

namespace Application.Features.Quizzes.Answer.Models;

public class AnswerListModel:BasePageableModel
{
    public IList<ListAnswerQueryResponse> Items { get; set; }
}