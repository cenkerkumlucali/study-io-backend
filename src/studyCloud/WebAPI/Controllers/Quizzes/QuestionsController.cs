using Application.Features.Answer.Dtos;
using Application.Features.Question.Commands.CreateQuestion;
using Application.Features.Question.Commands.DeleteQuestion;
using Application.Features.Question.Commands.UpdateQuestion;
using Application.Features.Question.Models;
using Application.Features.Question.Queries.GetByIdQuestion;
using Application.Features.Question.Queries.GetListByQuizId;
using Application.Features.Question.Queries.GetListQuestion;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Quizzes;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromQuery] CreateQuestionCommandRequest createQuestionCommand,
        [FromQuery] string createAnswerJson
    )
    {
        createQuestionCommand.CreateAnswerDtos = System.Text.Json.JsonSerializer.Deserialize<List<AnswerDto>>(createAnswerJson);
        createQuestionCommand.Files = createQuestionCommand.Files;
        CreateQuestionCommandResponse result = await Mediator.Send(createQuestionCommand);
        return Created("", result);
    }
    /*
     *
[
  {
    "content": "A",
    "isCorrect": false
  },
{
    "content": "B",
    "isCorrect": true
  },
{
    "content": "C",
    "isCorrect": false
  },
{
    "content": "D",
    "isCorrect": false
  },
{
    "content": "E",
    "isCorrect": false
  }
]
     */

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateQuestionCommandRequest updateQuestionCommand)
    {
        UpdateQuestionCommandResponse result = await Mediator.Send(updateQuestionCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteQuestionCommandRequest deleteQuestionCommand)
    {
        DeleteQuestionCommandResponse result = await Mediator.Send(deleteQuestionCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListQuestionQueryRequest getListQuestionQuery)
    {
        QuestionListModel result = await Mediator.Send(getListQuestionQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdQuestionQueryRequest getByIdQuestionQuery)
    {
        GetByIdQuestionQueryResponse result = await Mediator.Send(getByIdQuestionQuery);
        return Ok(result);
    }
    [HttpGet("[action]/{QuizId}")]
    public async Task<IActionResult> GetListByQuizId(
        [FromQuery] GetListByQuizIdQueryRequest getListByQuizIdQueryRequest)
    {
        GetByQuizIdModel result = await Mediator.Send(getListByQuizIdQueryRequest);
        return Ok(result);
    }
}