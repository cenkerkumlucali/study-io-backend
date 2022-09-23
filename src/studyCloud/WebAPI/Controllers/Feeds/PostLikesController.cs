using Application.Features.Feeds.PostLike.Commands.CreatePostLike;
using Application.Features.Feeds.PostLike.Commands.DeletePostLike;
using Application.Features.Feeds.PostLike.Commands.UpdatePostLike;
using Application.Features.Feeds.PostLike.Dtos;
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
        [FromBody] CreatePostLikeCommand createPostLikeCommand)
    {
        CreatedPostLikeDto result = await Mediator.Send(createPostLikeCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdatePostLikeCommand updatePostLikeCommand)
    {
        UpdatedPostLikeDto result = await Mediator.Send(updatePostLikeCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeletePostLikeCommand deletePostLikeCommand)
    {
        DeletedPostLikeDto result = await Mediator.Send(deletePostLikeCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListPostLikeQuery getListPostLikeQuery)
    {
        PostLikeListModel result = await Mediator.Send(getListPostLikeQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdPostLikeQuery getByIdPostLikeQuery)
    {
        GetByIdPostLikeDto result = await Mediator.Send(getByIdPostLikeQuery);
        return Ok(result);
    }
}