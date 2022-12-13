using Application.Features.FlashCards.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.FlashCards.Queries.GetListByLessonSubjectId;

public class GetListByLessonSubjectIdQueryRequest:IRequest<GetByLessonSubjectIdListModel>
{
    public PageRequest PageRequest { get; set; }
    public long LessonSubjectId { get; set; }
}