using Application.DTOs.Paging;
using Application.Features.FlashCards.Queries.GetListByLessonSubjectId;

namespace Application.Features.FlashCards.Models;

public class GetByLessonSubjectIdListModel:BasePageableModel
{
    public IList<GetListByLessonSubjectIdQueryResponse> Items { get; set; }
}