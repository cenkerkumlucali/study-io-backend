using Application.Features.Comments.Comment.Commands.CreateComment;
using Application.Features.Comments.Comment.Commands.DeleteComment;
using Application.Features.Comments.Comment.Commands.UpdateComment;
using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.Comment.Queries.GetByIdComment;
using Application.Features.Comments.Comment.Queries.GetByPostIdComment;
using Application.Features.Comments.Comment.Queries.GetListComment;
using Application.Features.Comments.CommentFile.Commands.CreateCommentFile;
using Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;
using Application.Features.Comments.CommentFile.Queries.GetListCommentFile;
using Application.Features.Comments.CommentLike.Commands.LikeComment;
using Application.Features.Comments.CommentLike.Commands.UnLikeComment;
using Application.Features.Comments.CommentLike.Queries.GetUsersLikedComment;
using Application.Features.Feeds.PostLike.Queries.GetMembersLikedPost;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : BaseController
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
        [FromRoute] GetByIdCommentQueryRequest getByIdCommentQuery)
    {
        GetByIdCommentQueryResponse result = await Mediator.Send(getByIdCommentQuery);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UploadImage(
        [FromQuery] CreateCommentImageFileCommandRequest createCommentFileCommandRequest)
    {
        createCommentFileCommandRequest.Files = Request.Form.Files;
        CreateCommentImageFileCommandResponse response = await Mediator.Send(createCommentFileCommandRequest);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetCommentImages(
        [FromRoute] GetListCommentFileQueryRequest listCommentFileQueryRequest)
    {
        ListCommentFileQueryResponse response = await Mediator.Send(listCommentFileQueryRequest);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteImage(
        [FromRoute] DeleteCommentFileCommandRequest deleteCommentFileCommandRequest, [FromQuery] string imageId)
    {
        deleteCommentFileCommandRequest.ImageId = imageId;
        DeleteCommentFileCommandResponse response = await Mediator.Send(deleteCommentFileCommandRequest);
        return Ok();
    }

    [HttpGet("[action]/{PostId}")]
    public async Task<IActionResult> GetByPostId(
        [FromRoute] GetByPostIdCommentQueryRequest getByPostIdCommentQueryRequest)
    {
        List<GetByPostIdCommentQueryResponse> response = await Mediator.Send(getByPostIdCommentQueryRequest);
        return Ok(response);
    }
    
    [HttpGet("[action]/{CommentId}")]
    public async Task<IActionResult> GetMembersLikedComment(
        [FromRoute] GetUsersLikedCommentQueryRequest getUsersLikedCommentQueryRequest)
    {
        List<GetUsersLikedCommentQueryResponse> response = await Mediator.Send(getUsersLikedCommentQueryRequest);
        return Ok(response);
    }

    [HttpPost("[action]/{UserId}/{CommentId}")]
    public async Task<IActionResult> Like(
        [FromRoute] LikeCommentCommandRequest createCommentLikeCommand)
    {
        LikeCommentCommandResponse response = await Mediator.Send(createCommentLikeCommand);
        return Ok(response);
    }

    [HttpDelete("[action]/{UserId}/{CommentId}")]
    public async Task<IActionResult> UnLike(
        [FromRoute] UnLikeCommentCommandRequest deleteCommentLikeCommand)
    {
        UnLikeCommentCommandResponse response = await Mediator.Send(deleteCommentLikeCommand);
        return Ok(response);
    }
}