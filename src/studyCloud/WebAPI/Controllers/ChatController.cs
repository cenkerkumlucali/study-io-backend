using Application.Features.Users.Chat.Commands.SendMessage;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Post(
        [FromBody] SendMessageCommandRequest sendMessageCommandRequest)
    {
        SendMessageCommandResponse result = await Mediator.Send(sendMessageCommandRequest);
        return Created("", result);
    }
}