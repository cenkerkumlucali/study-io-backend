using Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;
using Application.Features.Quizzes.QuizHistory.Commands.DeleteQuizHistory;
using Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;
using Application.Features.Quizzes.QuizHistory.Dtos;
using Application.Features.Quizzes.QuizHistory.Models;
using Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;
using Application.Features.Quizzes.QuizHistory.Queries.GetListQuizHistory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class QuizHistorysController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateQuizHistoryCommandRequest createQuizHistoryCommand)
    {
        CreateQuizHistoryCommandResponse result = await Mediator.Send(createQuizHistoryCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuizHistoryCommandRequest updateQuizHistoryCommand)
    {
        UpdateQuizHistoryQueryResponse result = await Mediator.Send(updateQuizHistoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuizHistoryCommandRequest deleteQuizHistoryCommand)
    {
        DeleteQuizHistoryCommandResponse result = await Mediator.Send(deleteQuizHistoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuizHistoryQueryRequest getListQuizHistoryQuery)
    {
        QuizHistoryListModel result = await Mediator.Send(getListQuizHistoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuizHistoryQueryRequest getByIdQuizHistoryQuery)
    {
        GetByIdQuizHistoryQueryResponse result = await Mediator.Send(getByIdQuizHistoryQuery);
        return Ok(result);
    }
}