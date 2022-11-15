using Application.Features.Feeds.PostImage.Commands.CreatePostImage;
using Application.Features.Feeds.PostImage.Commands.DeletePostImage;
using Application.Features.Feeds.PostImage.Commands.UpdatePostImage;
using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Feeds.PostImage.Models;
using Application.Features.Feeds.PostImage.Queries.GetByIdPostImage;
using Application.Features.Feeds.PostImage.Queries.GetListPostImage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Feeds;

[Route("api/[controller]")]
[ApiController]
public class PostImagesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreatePostImageCommandRequest createPostImageCommand)
    {
        CreatePostFileCommandResponse result = await Mediator.Send(createPostImageCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdatePostImageCommandRequest updatePostImageCommand)
    {
        UpdatedPostFileQueryResponse result = await Mediator.Send(updatePostImageCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeletePostImageCommandRequest deletePostImageCommand)
    {
        DeletePostFileCommandResponse result = await Mediator.Send(deletePostImageCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListPostImageQueryRequest getListPostImageQuery)
    {
        PostImageListModel result = await Mediator.Send(getListPostImageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdPostImageQueryRequest getByIdPostImageQuery)
    {
        GetByIdPostFileQueryResponse result = await Mediator.Send(getByIdPostImageQuery);
        return Ok(result);
    }
}