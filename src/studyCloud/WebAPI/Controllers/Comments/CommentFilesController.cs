using Application.Features.Comments.CommentFile.Commands.CreateCommentFile;
using Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;
using Application.Features.Comments.CommentFile.Commands.UpdateCommentFile;
using Application.Features.Comments.CommentFile.Models;
using Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;
using Application.Features.Comments.CommentFile.Queries.GetListCommentFile;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentFilesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCommentFileCommandRequest createCommentImageCommand)
    {
        CreateCommentFileCommandResponse result = await Mediator.Send(createCommentImageCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCommentFileCommandRequest updateCommentImageCommand)
    {
        UpdateCommentFileCommandResponse result = await Mediator.Send(updateCommentImageCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCommentFileCommandRequest deleteCommentImageCommand)
    {
        DeleteCommentFileCommandResponse result = await Mediator.Send(deleteCommentImageCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCommentFileQueryRequest getListCommentImageQuery)
    {
        CommentImageListModel result = await Mediator.Send(getListCommentImageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCommentFileQueryRequest getByIdCommentImageQuery)
    {
        GetByIdCommentFileQueryResponse result = await Mediator.Send(getByIdCommentImageQuery);
        return Ok(result);
    }
}