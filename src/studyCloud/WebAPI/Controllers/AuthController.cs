using Application.DTOs.User;
using Application.Features.Auths.Commands.DisableEmailAuthenticator;
using Application.Features.Auths.Commands.DisableOtpAuthenticator;
using Application.Features.Auths.Commands.EnableEmailAuthenticator;
using Application.Features.Auths.Commands.EnableOtpAuthenticator;
using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.RefreshTokenLogin;
using Application.Features.Auths.Commands.Register;
using Application.Features.Auths.Commands.VerifyEmailAuthenticator;
using Application.Features.Auths.Commands.VerifyOtpAuthenticator;
using Application.Features.Auths.Dtos;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly WebAPIConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration.GetSection("WebAPIConfiguration").Get<WebAPIConfiguration>();
    }

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
 
    [HttpGet("EnableEmailAuthenticator")]
    public async Task<IActionResult> EnableEmailAuthenticator([FromQuery] EnableEmailAuthenticatorCommandRequest enableEmailAuthenticatorCommandRequest)
    {
        enableEmailAuthenticatorCommandRequest.VerifyEmailUrlPrefix =
            $"{_configuration.APIDomain}/Auth/VerifyEmailAuthenticator";
        
        await Mediator.Send(enableEmailAuthenticatorCommandRequest);

        return Ok();
    }
    
    [HttpGet("DisableEmailAuthenticator")]
    public async Task<IActionResult> DisableEmailAuthenticator([FromQuery] DisableEmailAuthenticatorCommandRequest disableEmailAuthenticatorCommandRequest)
    {
        await Mediator.Send(disableEmailAuthenticatorCommandRequest);
        return Ok();
    }
    
    [HttpGet("VerifyEmailAuthenticator")]
    public async Task<IActionResult> VerifyEmailAuthenticator(
        [FromQuery] VerifyEmailAuthenticatorCommandRequest verifyEmailAuthenticatorCommandRequest)
    {
        await Mediator.Send(verifyEmailAuthenticatorCommandRequest);
        return Ok();
    }
    
    [HttpGet("EnableOtpAuthenticator")]
    public async Task<IActionResult> EnableOtpAuthenticator([FromQuery] EnableOtpAuthenticatorCommandRequest enableOtpAuthenticatorCommandRequest)
    {
        EnabledOtpAuthenticatorCommandResponse result = await Mediator.Send(enableOtpAuthenticatorCommandRequest);
        return Ok(result);
    }
    
    [HttpGet("DisableOtpAuthenticator")]
    public async Task<IActionResult> DisableOtpAuthenticator([FromQuery] DisableOtpAuthenticatorCommandRequest disableOtpAuthenticatorCommandRequest)
    {
        await Mediator.Send(disableOtpAuthenticatorCommandRequest);
        return Ok();
    }
    
    [HttpPost("VerifyOtpAuthenticator")]
    public async Task<IActionResult> VerifyOtpAuthenticator(
        [FromQuery] VerifyOtpAuthenticatorCommandRequest verifyOtpAuthenticatorCommandRequest)
    {
        await Mediator.Send(verifyOtpAuthenticatorCommandRequest);
        return Ok();
    }
    
    private string? GetRefreshTokenFromCookies()
    {
        return Request.Cookies["refreshToken"];
    }
    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true ,Expires = DateTime.Now.AddDays(7)};
        Response.Cookies.Append("refreshToken",refreshToken.Token, cookieOptions);
    }
}