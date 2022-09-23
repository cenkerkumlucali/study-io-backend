using Application.Features.Users.UserCoin.Commands.CreateUserCoin;
using Application.Features.Users.UserCoin.Commands.DeleteUserCoin;
using Application.Features.Users.UserCoin.Commands.UpdateUserCoin;
using Application.Features.Users.UserCoin.Dtos;
using Application.Features.Users.UserCoin.Models;
using Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;
using Application.Features.Users.UserCoin.Queries.GetListUserCoin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UserCoinsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateUserCoinCommand createUserCoinCommand)
    {
        CreatedUserCoinDto result = await Mediator.Send(createUserCoinCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateUserCoinCommand updateUserCoinCommand)
    {
        UpdatedUserCoinDto result = await Mediator.Send(updateUserCoinCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteUserCoinCommand deleteUserCoinCommand)
    {
        DeletedUserCoinDto result = await Mediator.Send(deleteUserCoinCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListUserCoinQuery getListUserCoinQuery)
    {
        UserCoinListModel result = await Mediator.Send(getListUserCoinQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdUserCoinQuery getByIdUserCoinQuery)
    {
        GetByIdUserCoinDto result = await Mediator.Send(getByIdUserCoinQuery);
        return Ok(result);
    }
}