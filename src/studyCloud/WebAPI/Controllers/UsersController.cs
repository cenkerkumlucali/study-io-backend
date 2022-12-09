using Application.Features.Users.ResetPassword.Commands;
using Application.Features.Users.User.Commands.DeleteUser;
using Application.Features.Users.User.Commands.EditProfile;
using Application.Features.Users.User.Queries.Profile;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommandRequest resetPasswordCommandRequest)
    {
        ResetPasswordCommandResponse response =  await Mediator.Send(resetPasswordCommandRequest);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> EditProfile([FromBody] EditProfileCommandRequest editProfileCommandRequest)
    {
        EditProfileCommandResponse response =  await Mediator.Send(editProfileCommandRequest);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommandRequest deleteUserCommandRequest)
    {
        DeleteUserCommandResponse response =  await Mediator.Send(deleteUserCommandRequest);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> Profile([FromQuery] ProfileQueryRequest profileQueryRequest)
    {
        ProfileQueryResponse response =  await Mediator.Send(profileQueryRequest);
        return Ok(response);
    }
    
    /*
    {
        "id": 6,
        "userName": "cenkerkumlucali564564",
        "firstName": "Cenker",
        "lastName": "Kumlucalı",
        "introduce": "Merhaba ben Cenker",
        "phoneNumber": "05514489217",
        "gender": 0
    }
    */
}