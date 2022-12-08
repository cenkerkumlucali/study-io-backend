using Application.DTOs.Paging;
using Application.Features.Quizzes.Question.Queries.GetListByQuizId;

namespace Application.Features.Quizzes.Question.Models;

public class GetByQuizIdModel:BasePageableModel
{
    public IList<GetListByQuizIdQueryResponse> Items { get; set; }
}