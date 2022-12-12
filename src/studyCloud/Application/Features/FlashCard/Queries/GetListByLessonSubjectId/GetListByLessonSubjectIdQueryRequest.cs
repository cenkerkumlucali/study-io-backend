using Application.Features.FlashCard.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.FlashCard.Queries.GetListByLessonSubjectId;

public class GetListByLessonSubjectIdQueryRequest:IRequest<GetByLessonSubjectIdListModel>
{
    public PageRequest PageRequest { get; set; }
    public long LessonSubjectId { get; set; }
}