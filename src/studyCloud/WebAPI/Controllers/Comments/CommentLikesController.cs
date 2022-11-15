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
        [FromBody] CreateCommentLikeCommandRequest createCommentLikeCommand)
    {
        CreateCommentLikeCommandResponse result = await Mediator.Send(createCommentLikeCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCommentLikeCommandRequest updateCommentLikeCommand)
    {
        UpdateCommentLikeCommandResponse result = await Mediator.Send(updateCommentLikeCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCommentLikeCommandRequest deleteCommentLikeCommand)
    {
        DeleteCommentLikeCommandResponse result = await Mediator.Send(deleteCommentLikeCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCommentLikeQueryRequest getListCommentLikeQueryRequest)
    {
        CommentLikeListModel result = await Mediator.Send(getListCommentLikeQueryRequest);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCommentLikeQueryRequest getByIdCommentLikeQuery)
    {
        GetByIdCommentLikeQueryResponse result = await Mediator.Send(getByIdCommentLikeQuery);
        return Ok(result);
    }
}