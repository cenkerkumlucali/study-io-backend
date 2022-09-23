using Application.Features.Comments.CommentImage.Commands.CreateCommentImage;
using Application.Features.Comments.CommentImage.Commands.DeleteCommentImage;
using Application.Features.Comments.CommentImage.Commands.UpdateCommentImage;
using Application.Features.Comments.CommentImage.Dtos;
using Application.Features.Comments.CommentImage.Models;
using Application.Features.Comments.CommentImage.Queries.GetByIdCommentImage;
using Application.Features.Comments.CommentImage.Queries.GetListCommentImage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentImagesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCommentImageCommand createCommentImageCommand)
    {
        CreatedCommentImageDto result = await Mediator.Send(createCommentImageCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCommentImageCommand updateCommentImageCommand)
    {
        UpdatedCommentImageDto result = await Mediator.Send(updateCommentImageCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCommentImageCommand deleteCommentImageCommand)
    {
        DeletedCommentImageDto result = await Mediator.Send(deleteCommentImageCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCommentImageQuery getListCommentImageQuery)
    {
        CommentImageListModel result = await Mediator.Send(getListCommentImageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCommentImageQuery getByIdCommentImageQuery)
    {
        GetByIdCommentImageDto result = await Mediator.Send(getByIdCommentImageQuery);
        return Ok(result);
    }
}