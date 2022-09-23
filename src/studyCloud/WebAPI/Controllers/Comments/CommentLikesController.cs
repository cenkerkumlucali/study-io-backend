using Application.Features.Comments.CommentLike.Commands.CreateCommentLike;
using Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;
using Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Features.Comments.CommentLike.Models;
using Application.Features.Comments.CommentLike.Queries.GetByIdCommentLike;
using Application.Features.Comments.CommentLike.Queries.GetListCommentLike;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentLikesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCommentLikeCommand createCommentLikeCommand)
    {
        CreatedCommentLikeDto result = await Mediator.Send(createCommentLikeCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCommentLikeCommand updateCommentLikeCommand)
    {
        UpdatedCommentLikeDto result = await Mediator.Send(updateCommentLikeCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCommentLikeCommand deleteCommentLikeCommand)
    {
        DeletedCommentLikeDto result = await Mediator.Send(deleteCommentLikeCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCommentLikeQuery getListCommentLikeQuery)
    {
        CommentLikeListModel result = await Mediator.Send(getListCommentLikeQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCommentLikeQuery getByIdCommentLikeQuery)
    {
        GetByIdCommentLikeDto result = await Mediator.Send(getByIdCommentLikeQuery);
        return Ok(result);
    }
}