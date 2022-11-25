using Application.Features.Follows.Commands.CreateFollow;
using Application.Features.Follows.Commands.DeleteFollower;
using Application.Features.Follows.Commands.UnFollow;
using Application.Features.Follows.Commands.UpdateFollow;
using Application.Features.Follows.Models;
using Application.Features.Follows.Queries.GetByIdFollow;
using Application.Features.Follows.Queries.GetFollowers;
using Application.Features.Follows.Queries.GetFollowings;
using Application.Features.Follows.Queries.GetListFollow;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

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

    [HttpDelete("[action]")]
    public async Task<IActionResult> UnFollow(
        [FromBody] UnFollowCommandRequest deleteFollowCommand)
    {
        UnFollowCommandResponse result = await Mediator.Send(deleteFollowCommand);
        return Created("", result);
    }
    
    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteFollower(
        [FromBody] DeleteFollowerCommandRequest deleteFollowerCommandRequest)
    {
        DeleteFollowerCommandResponse response = await Mediator.Send(deleteFollowerCommandRequest);
        return Ok(response);
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
    
    [HttpGet("[action]/{UserId}")]
    public async Task<IActionResult> GetFollewers(
        [FromRoute] GetFollowersQueryRequest getFollowersQueryRequest)
    {
        GetFollowersQueryResponse result = await Mediator.Send(getFollowersQueryRequest);
        return Ok(result);
    }
    
    [HttpGet("[action]/{UserId}")]
    public async Task<IActionResult> GetFollowings(
        [FromRoute] GetFollowingsQueryRequest getFollowingsQueryRequest)
    {
        List<GetFollowingsQueryResponse> result = await Mediator.Send(getFollowingsQueryRequest);
        return Ok(result);
    }
}