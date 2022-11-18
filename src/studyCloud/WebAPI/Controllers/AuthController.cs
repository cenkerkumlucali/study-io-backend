using Application.DTOs.User;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
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
    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true ,Expires = DateTime.Now.AddDays(7)};
        Response.Cookies.Append("refreshToken",refreshToken.Token, cookieOptions);
    }
}