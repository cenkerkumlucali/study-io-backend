using Application.Features.Lessons.Lesson.Commands.CreateLesson;
using Application.Features.Lessons.Lesson.Commands.DeleteLesson;
using Application.Features.Lessons.Lesson.Commands.UpdateLesson;
using Application.Features.Lessons.Lesson.Queries.GetLessonById;
using Application.Features.Lessons.Lesson.Queries.GetListBySubCategory;
using Application.Features.Lessons.Lesson.Queries.GetListLesson;
using Application.Features.Lessons.Lesson.Queries.GetListLessonByDynamic;
using Application.Persistence.Dynamic;
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
        CreateLessonCommandResponse response = await Mediator.Send(createLessonCommand);
        return Created("", response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateLessonCommandRequest updateLessonCommand)
    {
        UpdateLessonCommandResponse response = await Mediator.Send(updateLessonCommand);
        return Created("", response);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteLessonCommandRequest deleteLessonCommand)
    {
        DeleteLessonCommandResponse response = await Mediator.Send(deleteLessonCommand);
        return Created("", response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListLessonQueryRequest getListLessonQuery)
    {
        List<GetListLessonQueryResponse> response = await Mediator.Send(getListLessonQuery);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromRoute] GetByIdLessonQueryRequest getByIdLessonQuery)
    {
        List<GetByIdLessonQueryResponse> response = await Mediator.Send(getByIdLessonQuery);
        return Ok(response);
    }

    [HttpGet("[action]/{SubCategoryId}")]
    public async Task<IActionResult> GetListBySubCategory(
        [FromRoute] GetListBySubCategoryQueryRequest getListBySubCategoryQueryRequest)
    {
        List<GetListBySubCategoryQueryResponse> response = await Mediator.Send(getListBySubCategoryQueryRequest);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> GetListByDynamic([FromBody] Dynamic dynamic)
    {
        GetListLessonByDynamicQueryRequest getListModelByDynamicQuery = new GetListLessonByDynamicQueryRequest
            { Dynamic = dynamic };
        var result = await Mediator.Send(getListModelByDynamicQuery);
        return Ok(result);
    } 
/*
     {
  "sort": [
    {
      "field": "name",
      "dir": "asc"
    }
  ],
  "filter": {
    "field": "subCategoryId",
    "operator": "eq",
    "value": "19",
    "logic": "or",
    "filters": [{
     "field": "name",
     "operator": "eq",
      "value": "Edebiyat"
     } 
    ]
  }
}
*/
}