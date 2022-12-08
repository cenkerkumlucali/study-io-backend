using Application.Features.Lessons.Lesson.Commands.CreateLesson;
using Application.Features.Lessons.Lesson.Commands.DeleteLesson;
using Application.Features.Lessons.Lesson.Commands.UpdateLesson;
using Application.Features.Lessons.Lesson.Queries.GetListLessonSubjects;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateLessonCommandRequest createLessonCommand)
    {
        CreateLessonCommandResponse result = await Mediator.Send(createLessonCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateLessonCommandRequest updateLessonCommand)
    {
        UpdateLessonCommandResponse result = await Mediator.Send(updateLessonCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteLessonCommandRequest deleteLessonCommand)
    {
        DeleteLessonCommandResponse result = await Mediator.Send(deleteLessonCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetListLessonSubjects(
        [FromQuery] GetListLessonSubjectsQueryRequest getListLessonQuery)
    {
        List<GetListLessonSubjectsQueryResponse> result = await Mediator.Send(getListLessonQuery);
        return Ok(result);
    }

    // [HttpGet("{Id}")]
    // public async Task<IActionResult> GetById(
    //     [FromQuery] GetByIdLessonQueryRequest getByIdLessonQuery)
    // {
    //     GetByIdLessonQueryResponse result = await Mediator.Send(getByIdLessonQuery);
    //     return Ok(result);
    // }
}