using Application.Features.Quizzes.Question.Commands.CreateQuestion;
using Application.Features.Quizzes.Question.Commands.DeleteQuestion;
using Application.Features.Quizzes.Question.Commands.UpdateQuestion;
using Application.Features.Quizzes.Question.Dtos;
using Application.Features.Quizzes.Question.Models;
using Application.Features.Quizzes.Question.Queries.GetByIdQuestion;
using Application.Features.Quizzes.Question.Queries.GetListQuestion;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateQuestionCommand createQuestionCommand)
    {
        CreatedQuestionDto result = await Mediator.Send(createQuestionCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuestionCommand updateQuestionCommand)
    {
        UpdatedQuestionDto result = await Mediator.Send(updateQuestionCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuestionCommand deleteQuestionCommand)
    {
        DeletedQuestionDto result = await Mediator.Send(deleteQuestionCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuestionQuery getListQuestionQuery)
    {
        QuestionListModel result = await Mediator.Send(getListQuestionQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuestionQuery getByIdQuestionQuery)
    {
        GetByIdQuestionDto result = await Mediator.Send(getByIdQuestionQuery);
        return Ok(result);
    }
}