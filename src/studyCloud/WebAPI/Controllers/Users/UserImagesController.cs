using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Dtos;
using Application.Features.Users.UserImage.Models;
using Application.Features.Users.UserImage.Queries.GetByIdUserCoin;
using Application.Features.Users.UserImage.Queries.GetListUserCoin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UserImagesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateUserImageCommand createUserImageCommand)
    {
        CreatedUserImageDto result = await Mediator.Send(createUserImageCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateUserImageCommand updateUserImageCommand)
    {
        UpdatedUserImageDto result = await Mediator.Send(updateUserImageCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteUserImageCommand deleteUserImageCommand)
    {
        DeletedUserImageDto result = await Mediator.Send(deleteUserImageCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListUserImageQuery getListUserImageQuery)
    {
        UserImageListModel result = await Mediator.Send(getListUserImageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdUserImageQuery getByIdUserImageQuery)
    {
        GetByIdUserImageDto result = await Mediator.Send(getByIdUserImageQuery);
        return Ok(result);
    }
}