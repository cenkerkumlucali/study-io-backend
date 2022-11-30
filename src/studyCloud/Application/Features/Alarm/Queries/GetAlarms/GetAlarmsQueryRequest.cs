using MediatR;

namespace Application.Features.Alarm.Queries.GetAlarms;

public class GetAlarmsQueryRequest:IRequest<List<GetAlarmsQueryResponse>>
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}