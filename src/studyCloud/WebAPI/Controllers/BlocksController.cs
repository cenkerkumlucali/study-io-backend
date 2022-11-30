using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategory;
using Application.Features.Users.Block.Commands.CreateBlock;
using Application.Features.Users.Block.Commands.DeleteBlock;
using Application.Features.Users.Block.Queries.GetByUserId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlocksController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Block(
        [FromBody] CreateBlockCommandRequest createBlockCommandRequest)
    {
        CreateBlockCommandResponse result = await Mediator.Send(createBlockCommandRequest);
        return Created("", result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Block(
        [FromBody] DeleteBlockCommandRequest deleteBlockCommandRequest)
    {
        DeleteBlockCommandResponse result = await Mediator.Send(deleteBlockCommandRequest);
        return Created("", result);
    }
    
    [HttpGet("blocks/{UserId}")]
    public async Task<IActionResult> GetByUserId(
        [FromRoute] GetByUserIdQueryRequest getByUserIdQueryRequest)
    {
        List<GetByUserIdQueryResponse> response = await Mediator.Send(getByUserIdQueryRequest);
        return Ok(response);
    }
}