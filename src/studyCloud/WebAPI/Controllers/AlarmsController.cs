using Application.Features.Alarm.Queries.GetAlarms;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlarmsController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAlarms([FromQuery] GetAlarmsQueryRequest getAlarmsQueryRequest)
    {
        List<GetAlarmsQueryResponse> result = await Mediator.Send(getAlarmsQueryRequest);
        return Ok(result);
    }
}