using Application.Features.Mentions.Dtos;
using Application.Features.Quizzes.Answer.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Answer.Models;

public class AnswerListModel:BasePageableModel
{
    public IList<ListAnswerDto> Items { get; set; }
}