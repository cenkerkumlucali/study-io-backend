using Application.Features.Quiz.Commands.CreateQuiz;
using Application.Features.Quiz.Commands.DeleteQuiz;
using Application.Features.Quiz.Commands.UpdateQuiz;
using Application.Features.Quiz.Models;
using Application.Features.Quiz.Queries.GetByIdQuiz;
using Application.Features.Quiz.Queries.GetByPublisherId;
using Application.Features.Quiz.Queries.GetListQuiz;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class QuizzesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateQuizCommandRequest createQuizCommand)
    {
        CreateQuizCommandResponse result = await Mediator.Send(createQuizCommand);
        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuizCommandRequest updateQuizCommand)
    {
        UpdateQuizCommandResponse result = await Mediator.Send(updateQuizCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuizCommandRequest deleteQuizCommand)
    {
        DeleteQuizCommandResponse result = await Mediator.Send(deleteQuizCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuizQueryRequest getListQuizQuery)
    {
        QuizListModel result = await Mediator.Send(getListQuizQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuizQueryRequest getByIdQuizQuery)
    {
        GetByIdQuizQueryResponse result = await Mediator.Send(getByIdQuizQuery);
        return Ok(result);
    }
    
    [HttpGet("[action]/{PublisherId}")]
    public async Task<IActionResult> GetByPublisherId(
        [FromRoute] GetByPublisherIdQueryRequest getByPublisherIdQueryRequest)
    {
        GetByPublisherIdQueryResponse result = await Mediator.Send(getByPublisherIdQueryRequest);
        return Ok(result);
    }
}