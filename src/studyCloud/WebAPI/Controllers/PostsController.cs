using Application.Features.Post.Commands.CreatePost;
using Application.Features.Post.Commands.DeletePost;
using Application.Features.Post.Commands.UpdatePost;
using Application.Features.Post.Models;
using Application.Features.Post.Queries.GetByIdPost;
using Application.Features.Post.Queries.GetListByUserId;
using Application.Features.Post.Queries.GetListPost;
using Application.Features.PostImageFile.Commands.CreatePostImage;
using Application.Features.PostImageFile.Commands.DeletePostImage;
using Application.Features.PostImageFile.Models;
using Application.Features.PostImageFile.Queries.GetListPostImage;
using Application.Features.PostLike.Commands.LikePost;
using Application.Features.PostLike.Commands.UnLikePost;
using Application.Features.PostLike.Queries.GetMembersLikedPost;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromQuery] CreatePostCommandRequest createPostCommand)
    {
        CreatePostCommandResponse result = await Mediator.Send(createPostCommand);
        return Created("", result);
    }

    [HttpPut("update")]
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
    [HttpGet("[action]")]
    public async Task<IActionResult> GetListByUserId(
        [FromQuery] GetListByUserIdQueryRequest getListByUserIdQueryRequest)
    {
        GetListByUserIdQueryResponse result = await Mediator.Send(getListByUserIdQueryRequest);
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
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetMembersLikedPost(
        [FromQuery] GetMembersLikedPostQueryRequest getMembersLikedPostQueryRequest)
    {
        List<GetMembersLikedPostQueryResponse> response = await Mediator.Send(getMembersLikedPostQueryRequest);
        return Ok(response);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> LikePost(
        [FromBody] LikePostCommandRequest createPostLikeCommandRequest)
    {
        LikePostCommandResponse response = await Mediator.Send(createPostLikeCommandRequest);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> UnLikePost(
        [FromBody] UnLikePostCommandRequest deletePostLikeCommand)
    {
        UnLikePostCommandResponse response = await Mediator.Send(deletePostLikeCommand);
        return Ok(response);
    }
}