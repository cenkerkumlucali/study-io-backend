using Application.DTOs.Paging;
using Application.Features.Question.Queries.GetListByQuizId;

namespace Application.Features.Question.Models;

public class GetByQuizIdModel:BasePageableModel
{
    public IList<GetListByQuizIdQueryResponse> Items { get; set; }
}