using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.Post.Queries.GetByIdPost;
using Application.Features.Feeds.Post.Queries.GetListPost;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Feeds;

[Route("api/[controller]")]
[ApiController]
public class PostsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreatePostCommandRequest createPostCommand)
    {
        CreatePostCommandResponse result = await Mediator.Send(createPostCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdatePostCommandRequest updatePostCommand)
    {
        UpdatePostCommandResponse result = await Mediator.Send(updatePostCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeletePostCommandRequest deletePostCommand)
    {
        DeletePostCommandResponse result = await Mediator.Send(deletePostCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListPostQueryRequest getListPostQuery)
    {
        PostListModel result = await Mediator.Send(getListPostQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdPostQueryRequest getByIdPostQuery)
    {
        GetByIdPostQueryResponse result = await Mediator.Send(getByIdPostQuery);
        return Ok(result);
    }
}