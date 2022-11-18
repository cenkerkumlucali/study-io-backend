using Application.Features.Quizzes.Answer.Commands.CreateAnswer;
using Application.Features.Quizzes.Answer.Commands.DeleteAnswer;
using Application.Features.Quizzes.Answer.Commands.UpdateAnswer;
using Application.Features.Quizzes.Answer.Models;
using Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;
using Application.Features.Quizzes.Answer.Queries.GetListAnswer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class AnswersController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateAnswerCommandRequest createAnswerCommand)
    {
        CreateAnswerCommandResponse result = await Mediator.Send(createAnswerCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateAnswerCommandRequest updateAnswerCommand)
    {
        UpdatedAnswerCommandResponse result = await Mediator.Send(updateAnswerCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteAnswerCommandRequest deleteAnswerCommand)
    {
        DeleteAnswerCommandResponse result = await Mediator.Send(deleteAnswerCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListAnswerQueryRequest getListAnswerQuery)
    {
        AnswerListModel result = await Mediator.Send(getListAnswerQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdAnswerQueryRequest getByIdAnswerQuery)
    {
        GetByIdAnswerQueryResponse result = await Mediator.Send(getByIdAnswerQuery);
        return Ok(result);
    }
}