using Application.Features.Quizzes.Quiz.Commands.CreateQuiz;
using Application.Features.Quizzes.Quiz.Commands.DeleteQuiz;
using Application.Features.Quizzes.Quiz.Commands.UpdateQuiz;
using Application.Features.Quizzes.Quiz.Dtos;
using Application.Features.Quizzes.Quiz.Models;
using Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;
using Application.Features.Quizzes.Quiz.Queries.GetListQuiz;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class QuizzesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateQuizCommand createQuizCommand)
    {
        CreatedQuizDto result = await Mediator.Send(createQuizCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuizCommand updateQuizCommand)
    {
        UpdatedQuizDto result = await Mediator.Send(updateQuizCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuizCommand deleteQuizCommand)
    {
        DeletedQuizDto result = await Mediator.Send(deleteQuizCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuizQuery getListQuizQuery)
    {
        QuizListModel result = await Mediator.Send(getListQuizQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuizQuery getByIdQuizQuery)
    {
        GetByIdQuizDto result = await Mediator.Send(getByIdQuizQuery);
        return Ok(result);
    }
}