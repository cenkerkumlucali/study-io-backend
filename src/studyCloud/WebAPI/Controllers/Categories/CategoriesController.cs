using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.GetByIdCategory;
using Application.Features.Categories.Queries.GetListCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Categories;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryDto result = await Mediator.Send(createCategoryCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateCategoryCommand updateCategoryCommand)
    {
        UpdatedCategoryDto result = await Mediator.Send(updateCategoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteCategoryCommand deleteCategoryCommand)
    {
        DeletedCategoryDto result = await Mediator.Send(deleteCategoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListCategoryQuery getListCategoryQuery)
    {
        CategoryListModel result = await Mediator.Send(getListCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdCategoryQuery getByIdCategoryQuery)
    {
        GetByIdCategoryDto result = await Mediator.Send(getByIdCategoryQuery);
        return Ok(result);
    }
}