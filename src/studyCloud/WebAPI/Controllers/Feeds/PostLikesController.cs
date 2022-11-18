using Application.Features.Feeds.PostLike.Commands.CreatePostLike;
using Application.Features.Feeds.PostLike.Commands.DeletePostLike;
using Application.Features.Feeds.PostLike.Commands.UpdatePostLike;
using Application.Features.Feeds.PostLike.Models;
using Application.Features.Feeds.PostLike.Queries.GetByIdPostLike;
using Application.Features.Feeds.PostLike.Queries.GetListPostLike;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Feeds;

[Route("api/[controller]")]
[ApiController]
public class PostLikesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreatePostLikeCommandRequest createPostLikeCommandRequest)
    {
        CreatePostLikeCommandResponse result = await Mediator.Send(createPostLikeCommandRequest);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdatePostLikeCommandRequest updatePostLikeCommand)
    {
        UpdatePostLikeCommandResponse result = await Mediator.Send(updatePostLikeCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeletePostLikeCommandRequest deletePostLikeCommand)
    {
        DeletePostLikeCommandResponse result = await Mediator.Send(deletePostLikeCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListPostLikeQueryRequest getListPostLikeQuery)
    {
        PostLikeListModel result = await Mediator.Send(getListPostLikeQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdPostLikeQueryRequest getByIdPostLikeQuery)
    {
        GetByIdPostLikeQueryResponse result = await Mediator.Send(getByIdPostLikeQuery);
        return Ok(result);
    }
}