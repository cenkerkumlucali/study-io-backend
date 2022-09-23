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
        [FromBody] CreateQuizHistoryCommand createQuizHistoryCommand)
    {
        CreatedQuizHistoryDto result = await Mediator.Send(createQuizHistoryCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuizHistoryCommand updateQuizHistoryCommand)
    {
        UpdatedQuizHistoryDto result = await Mediator.Send(updateQuizHistoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuizHistoryCommand deleteQuizHistoryCommand)
    {
        DeletedQuizHistoryDto result = await Mediator.Send(deleteQuizHistoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuizHistoryQuery getListQuizHistoryQuery)
    {
        QuizHistoryListModel result = await Mediator.Send(getListQuizHistoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuizHistoryQuery getByIdQuizHistoryQuery)
    {
        GetByIdQuizHistoryDto result = await Mediator.Send(getByIdQuizHistoryQuery);
        return Ok(result);
    }
}