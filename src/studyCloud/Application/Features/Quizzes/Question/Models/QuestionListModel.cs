using Application.Features.Quizzes.Answer.Dtos;
using Application.Features.Quizzes.Question.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Quizzes.Question.Models;

public class QuestionListModel:BasePageableModel
{
    public IList<ListQuestionDto> Items { get; set; }
}