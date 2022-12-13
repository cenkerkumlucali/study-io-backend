using Application.Features.FlashCards.Commands.CreateFlashCard;
using Application.Features.FlashCards.Commands.DeleteFlashCard;
using Application.Features.FlashCards.Commands.UpdateFlashCard;
using Application.Features.FlashCards.Models;
using Application.Features.FlashCards.Queries.GetListByLessonSubjectId;
using Microsoft.AspNetCore.Mvc; 

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FlashCardsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateFlashCardCommandRequest createFlashCardCommand)
    {
        CreateFlashCardCommandResponse result = await Mediator.Send(createFlashCardCommand);
        return Created("Kaydedildi", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateFlashCardCommandRequest updateFlashCardCommand)
    {
        UpdateFlashCardCommandResponse result = await Mediator.Send(updateFlashCardCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteFlashCardCommandRequest deleteFlashCardCommand)
    {
        DeleteFlashCardCommandResponse result = await Mediator.Send(deleteFlashCardCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetListByLessonSubjectId(
        [FromQuery] GetListByLessonSubjectIdQueryRequest getListByLessonSubjectIdQueryRequest)
    {
        GetByLessonSubjectIdListModel result = await Mediator.Send(getListByLessonSubjectIdQueryRequest);
        return Ok(result);
    }
   
}