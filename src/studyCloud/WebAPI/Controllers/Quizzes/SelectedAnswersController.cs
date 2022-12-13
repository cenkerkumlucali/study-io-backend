using Application.Features.SelectedAnswer.Commands.CreateSelectedAnswer;
using Application.Features.SelectedAnswer.Commands.DeleteSelectedAnswer;
using Application.Features.SelectedAnswer.Commands.UpdateSelectedAnswer;
using Application.Features.SelectedAnswer.Models;
using Application.Features.SelectedAnswer.Queries.GetByIdSelectedAnswer;
using Application.Features.SelectedAnswer.Queries.GetListSelectedAnswer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class SelectedAnswersController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateSelectedAnswerCommandRequest createSelectedAnswerCommand)
    {
        CreateSelectedAnswerCommandResponse result = await Mediator.Send(createSelectedAnswerCommand);
        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateSelectedAnswerCommandRequest updateSelectedAnswerCommand)
    {
        UpdateSelectedAnswerCommandResponse result = await Mediator.Send(updateSelectedAnswerCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteSelectedAnswerCommandRequest deleteSelectedAnswerCommand)
    {
        DeleteSelectedAnswerCommandResponse result = await Mediator.Send(deleteSelectedAnswerCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListSelectedAnswerQueryRequest getListSelectedAnswerQuery)
    {
        SelectedAnswerListModel result = await Mediator.Send(getListSelectedAnswerQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdSelectedAnswerQueryRequest getByIdSelectedAnswerQuery)
    {
        GetByIdSelectedAnswerQueryResponse result = await Mediator.Send(getByIdSelectedAnswerQuery);
        return Ok(result);
    }
}