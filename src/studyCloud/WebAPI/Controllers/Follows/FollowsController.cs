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
        [FromBody] CreateFollowCommand createFollowCommand)
    {
        CreatedFollowDto result = await Mediator.Send(createFollowCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateFollowCommand updateFollowCommand)
    {
        UpdatedFollowDto result = await Mediator.Send(updateFollowCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteFollowCommand deleteFollowCommand)
    {
        DeletedFollowDto result = await Mediator.Send(deleteFollowCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListFollowQuery getListFollowQuery)
    {
        FollowListModel result = await Mediator.Send(getListFollowQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdFollowQuery getByIdFollowQuery)
    {
        GetByIdFollowDto result = await Mediator.Send(getByIdFollowQuery);
        return Ok(result);
    }
}