using Application.DTOs.Paging;
using Application.Features.FlashCard.Queries.GetListByLessonSubjectId;

namespace Application.Features.FlashCard.Models;

public class GetByLessonSubjectIdListModel:BasePageableModel
{
    public IList<GetListByLessonSubjectIdQueryResponse> Items { get; set; }
}