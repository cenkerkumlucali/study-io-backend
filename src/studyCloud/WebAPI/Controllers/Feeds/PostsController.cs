using Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;
using Application.Features.Feeds.Post.Commands.CreatePost;
using Application.Features.Feeds.Post.Commands.DeletePost;
using Application.Features.Feeds.Post.Commands.UpdatePost;
using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.Post.Queries.GetByIdPost;
using Application.Features.Feeds.Post.Queries.GetListPost;
using Application.Features.Feeds.PostImageFile.Commands.CreatePostImage;
using Application.Features.Feeds.PostImageFile.Commands.DeletePostImage;
using Application.Features.Feeds.PostImageFile.Models;
using Application.Features.Feeds.PostImageFile.Queries.GetListPostImage;
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
        [FromRoute] GetByIdPostQueryRequest getByIdPostQuery)
    {
        GetByIdPostQueryResponse result = await Mediator.Send(getByIdPostQuery);
        return Ok(result);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> UploadImage(
        [FromQuery] CreatePostImageFileCommandRequest createPostImageFileCommandRequest)
    {
        createPostImageFileCommandRequest.Files = Request.Form.Files;
        CreatePostImageFileCommandResponse response = await Mediator.Send(createPostImageFileCommandRequest);
        return Ok();
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetPostImages(
        [FromRoute] GetListPostImageFileQueryRequest getListPostImageFileQueryRequest)
    {
        PostImageListModel response = await Mediator.Send(getListPostImageFileQueryRequest);
        return Ok(response);
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteImage(
        [FromRoute] DeletePostImageCommandRequest deletePostImageCommandRequest, [FromQuery] int imageId)
    {
        deletePostImageCommandRequest.ImageId = imageId;
        DeletePostFileCommandResponse response = await Mediator.Send(deletePostImageCommandRequest);
        return Ok(response);
    }
}