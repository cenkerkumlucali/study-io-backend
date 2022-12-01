using Application.DTOs.User;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Users.ResetPassword;
using Application.Features.Users.ResetPassword.Commands;
using Application.Features.Users.User.Commands.EditProfile;
using Application.Features.Users.User.Queries.Profile;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpPost("[action]")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommandRequest resetPasswordCommandRequest)
    {
        Unit response =  await Mediator.Send(resetPasswordCommandRequest);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> EditProfile([FromBody] EditProfileCommandRequest editProfileCommandRequest)
    {
        EditProfileCommandResponse response =  await Mediator.Send(editProfileCommandRequest);
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
        "userId": 6,
        "userName": "cenkerkumlucali564564",
        "firstName": "Cenker",
        "lastName": "Kumlucalı",
        "indroduce": "Merhaba ben Cenker",
        "phoneNumber": "05514489217",
        "gender": 0
    }
    */
}