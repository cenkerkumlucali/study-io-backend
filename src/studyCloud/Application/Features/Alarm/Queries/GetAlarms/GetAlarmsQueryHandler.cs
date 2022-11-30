using Application.Abstractions.Services;
using Application.Features.Alarm.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Alarm.Queries.GetAlarms;

public class GetAlarmsQueryHandler:IRequestHandler<GetAlarmsQueryRequest,List<GetAlarmsQueryResponse>>
{
    private readonly IAlarmService _alarmService;
    private IMapper _mapper;

    public GetAlarmsQueryHandler(IAlarmService alarmService, IMapper mapper)
    {
        _alarmService = alarmService;
        _mapper = mapper;
    }

    public async Task<List<GetAlarmsQueryResponse>> Handle(GetAlarmsQueryRequest request, CancellationToken cancellationToken)
    {
        IList<AlarmDto> alarmDtos = await _alarmService.GetAlarms(request.UserId, request.Page, request.Size);
        List<GetAlarmsQueryResponse>? mappedAlarms = _mapper.Map<List<GetAlarmsQueryResponse>>(alarmDtos);
        return mappedAlarms;
    }
}