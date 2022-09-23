using Application.Features.Quizzes.Answer.Commands.CreateAnswer;
using Application.Features.Quizzes.Answer.Commands.DeleteAnswer;
using Application.Features.Quizzes.Answer.Commands.UpdateAnswer;
using Application.Features.Quizzes.Answer.Dtos;
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
        [FromBody] CreateAnswerCommand createAnswerCommand)
    {
        CreatedAnswerDto result = await Mediator.Send(createAnswerCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateAnswerCommand updateAnswerCommand)
    {
        UpdatedAnswerDto result = await Mediator.Send(updateAnswerCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteAnswerCommand deleteAnswerCommand)
    {
        DeletedAnswerDto result = await Mediator.Send(deleteAnswerCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListAnswerQuery getListAnswerQuery)
    {
        AnswerListModel result = await Mediator.Send(getListAnswerQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdAnswerQuery getByIdAnswerQuery)
    {
        GetByIdAnswerDto result = await Mediator.Send(getByIdAnswerQuery);
        return Ok(result);
    }
}