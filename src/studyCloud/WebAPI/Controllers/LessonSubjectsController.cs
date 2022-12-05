using Application.Features.Lessons.LessonSubject.Commands.CreateLessonSubject;
using Application.Features.Lessons.LessonSubject.Commands.DeleteLessonSubject;
using Application.Features.Lessons.LessonSubject.Commands.UpdateLessonSubject;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonSubjectsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateLessonSubjectCommandRequest createLessonSubjectCommand)
    {
        CreateLessonSubjectCommandResponse result = await Mediator.Send(createLessonSubjectCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateLessonSubjectCommandRequest updateLessonSubjectCommand)
    {
        UpdateLessonSubjectCommandResponse result = await Mediator.Send(updateLessonSubjectCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteLessonSubjectCommandRequest deleteLessonSubjectCommand)
    {
        DeleteLessonSubjectCommandResponse result = await Mediator.Send(deleteLessonSubjectCommand);
        return Created("", result);
    }

    // [HttpGet]
    // public async Task<IActionResult> GetList(
    //     [FromQuery] GetListLessonSubjectQueryRequest getListLessonSubjectQuery)
    // {
    //     LessonSubjectListModel result = await Mediator.Send(getListLessonSubjectQuery);
    //     return Ok(result);
    // }

    // [HttpGet("{Id}")]
    // public async Task<IActionResult> GetById(
    //     [FromQuery] GetByIdLessonSubjectQueryRequest getByIdLessonSubjectQuery)
    // {
    //     GetByIdLessonSubjectQueryResponse result = await Mediator.Send(getByIdLessonSubjectQuery);
    //     return Ok(result);
    // }
}