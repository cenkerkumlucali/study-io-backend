using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCategoryCommandRequest createCategoryCommand)
    {
        CreatedCategoryCommandResponse result = await Mediator.Send(createCategoryCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCategoryCommandRequest updateCategoryCommand)
    {
        UpdatedCategoryCommandResponse result = await Mediator.Send(updateCategoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCategoryCommandRequest deleteCategoryCommand)
    {
        DeletedCategoryCommandResponse result = await Mediator.Send(deleteCategoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCategoryQueryRequest getListCategoryQuery)
    {
        CategoryListModel result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCategoryQueryRequest getByIdCategoryQuery)
    {
        GetByIdCategoryQueryResponse result = await Mediator.Send(getByIdCategoryQuery);
        return Ok(result);
    }
}