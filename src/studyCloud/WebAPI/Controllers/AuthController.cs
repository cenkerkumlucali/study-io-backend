using Application.DTOs.User;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Application.Features.Users.RefreshTokenLogin;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
    {
        RegisterCommandRequest registerCommand = new()
        {
            UserForRegisterDto = userForRegisterDto,
            IPAddress = GetIpAddress()
        };

        RegisterCommandResponse result = await Mediator.Send(registerCommand);
        SetRefreshTokenToCookie(result.RefreshToken);
        return Created("",result.AccessToken);
    }
    /*
    {
        "email": "cenkerkumlucali@gmail.com",
         "password": "string"
     }
     */
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
    {
        LoginCommandRequest loginCommand = new()
        {
            UserForLoginDto = userForLoginDto,
            IPAddress = GetIpAddress()
        };
            
        LoginCommandResponse result = await Mediator.Send(loginCommand);

        SetRefreshTokenToCookie(result.RefreshToken);

        return Ok(result.AccessToken);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommandRequest refreshTokenCommandRequest)
    {
        RefreshTokenCommandResponse response = await Mediator.Send(refreshTokenCommandRequest);
        return Ok(response);
    }
    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true ,Expires = DateTime.Now.AddDays(7)};
        Response.Cookies.Append("refreshToken",refreshToken.Token, cookieOptions);
    }
}