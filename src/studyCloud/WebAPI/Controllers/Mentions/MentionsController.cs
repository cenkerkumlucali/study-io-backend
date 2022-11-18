using Application.Features.Mentions.Commands.CreateMention;
using Application.Features.Mentions.Commands.DeleteMention;
using Application.Features.Mentions.Commands.UpdateMention;
using Application.Features.Mentions.Models;
using Application.Features.Mentions.Queries.GetByIdMention;
using Application.Features.Mentions.Queries.GetListMention;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Mentions;

[Route("api/[controller]")]
[ApiController]
public class MentionsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateMentionCommandRequest createMentionCommand)
    {
        CreateMentionCommandResponse result = await Mediator.Send(createMentionCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateMentionCommandRequest updateMentionCommand)
    {
        UpdateMentionCommandResponse result = await Mediator.Send(updateMentionCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteMentionCommandRequest deleteMentionCommand)
    {
        DeleteMentionCommandResponse result = await Mediator.Send(deleteMentionCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListMentionQueryRequest getListMentionQuery)
    {
        MentionListModel result = await Mediator.Send(getListMentionQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdMentionQueryRequest getByIdMentionQuery)
    {
        GetByIdMentionQueryResponse result = await Mediator.Send(getByIdMentionQuery);
        return Ok(result);
    }
}