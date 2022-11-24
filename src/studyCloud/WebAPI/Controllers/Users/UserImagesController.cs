using Application.Features.Users.UserImage.Commands.CreateUserImage;
using Application.Features.Users.UserImage.Commands.DeleteUserImage;
using Application.Features.Users.UserImage.Commands.UpdateUserImage;
using Application.Features.Users.UserImage.Models;
using Application.Features.Users.UserImage.Queries.GetByIdUserImage;
using Application.Features.Users.UserImage.Queries.GetListUserImage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UserImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromQuery] CreateUserImageCommandRequest createUserImageCommand)
    {
        CreateUserImageCommandResponse result = await Mediator.Send(createUserImageCommand);
        return Created("", result);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(
        [FromQuery] UpdateUserImageCommandRequest updateUserImageCommand)
    {
        UpdateUserImageCommandResponse result = await Mediator.Send(updateUserImageCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteUserImageCommandRequest deleteUserImageCommand)
    {
        DeleteUserImageCommandResponse result = await Mediator.Send(deleteUserImageCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListUserImageQueryRequest getListUserImageQuery)
    {
        UserImageListModel result = await Mediator.Send(getListUserImageQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdUserImageQueryRequest getByIdUserImageQuery)
    {
        GetByIdUserImageQueryResponse result = await Mediator.Send(getByIdUserImageQuery);
        return Ok(result);
    }
}