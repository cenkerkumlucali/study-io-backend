using Application.DTOs.User;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Users.ResetPassword;
using Application.Features.Users.ResetPassword.Commands;
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
    
}