using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.Comment.Queries.GetByIdComment;
using Application.Features.Comments.Comment.Queries.GetListComment;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCommentCommandRequest createCommentCommand)
    {
        CreateCommentCommandResponse result = await Mediator.Send(createCommentCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCommentCommandRequest updateCommentCommand)
    {
        UpdateCommentCommandResponse result = await Mediator.Send(updateCommentCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCommentCommandRequest deleteCommentCommand)
    {
        DeleteCommentCommandResponse result = await Mediator.Send(deleteCommentCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCommentQueryRequest getListCommentQuery)
    {
        CommentListModel result = await Mediator.Send(getListCommentQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCommentQueryRequest getByIdCommentQuery)
    {
        GetByIdCommentQueryResponse result = await Mediator.Send(getByIdCommentQuery);
        return Ok(result);
    }
}