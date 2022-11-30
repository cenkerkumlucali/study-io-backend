using Application.Features.Alarm.Dtos;
using Application.Features.Alarm.Queries.GetAlarms;
using AutoMapper;

namespace Application.Features.Alarm.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<AlarmDto, GetAlarmsQueryRequest>().ReverseMap();
        CreateMap<AlarmDto, GetAlarmsQueryResponse>().ReverseMap();
       
    }
}