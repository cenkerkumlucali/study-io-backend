using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Commands.DeleteFollow;
using Application.Features.Follows.Commands.UpdateFollow;
using Application.Features.Follows.Dtos;
using Application.Features.Follows.Models;
using Application.Features.Follows.Queries.GetByIdFollow;
using Application.Features.Follows.Queries.GetListFollow;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Follows;

[Route("api/[controller]")]
[ApiController]
public class FollowsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateFollowCommandRequest createFollowCommand)
    {
        CreateFollowCommandResponse result = await Mediator.Send(createFollowCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateFollowCommandRequest updateFollowCommand)
    {
        UpdateFollowCommandResponse result = await Mediator.Send(updateFollowCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteFollowCommandRequest deleteFollowCommand)
    {
        DeleteFollowCommandResponse result = await Mediator.Send(deleteFollowCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListFollowQueryRequest getListFollowQuery)
    {
        FollowListModel result = await Mediator.Send(getListFollowQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdFollowQueryRequest getByIdFollowQuery)
    {
        GetByIdFollowQueryResponse result = await Mediator.Send(getByIdFollowQuery);
        return Ok(result);
    }
}