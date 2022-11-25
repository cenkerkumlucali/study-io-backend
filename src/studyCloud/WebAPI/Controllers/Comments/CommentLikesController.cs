using Application.Features.Comments.CommentLike.Models;
using Application.Features.Comments.CommentLike.Queries.GetByIdCommentLike;
using Application.Features.Comments.CommentLike.Queries.GetListCommentLike;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Comments;

[Route("api/[controller]")]
[ApiController]
public class CommentLikesController : BaseController
{
    

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