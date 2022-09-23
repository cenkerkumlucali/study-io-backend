using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.DeleteSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Dtos;
using Application.Features.SubCategories.Models;
using Application.Features.SubCategories.Queries.GetByIdSubCategory;
using Application.Features.SubCategories.Queries.GetListSubCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.SubCategories;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateSubCategoryCommand createSubCategoryCommand)
    {
        CreatedSubCategoryDto result = await Mediator.Send(createSubCategoryCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateSubCategoryCommand updateSubCategoryCommand)
    {
        UpdatedSubCategoryDto result = await Mediator.Send(updateSubCategoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteSubCategoryCommand deleteSubCategoryCommand)
    {
        DeletedSubCategoryDto result = await Mediator.Send(deleteSubCategoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListSubCategoryQuery getListSubCategoryQuery)
    {
        SubCategoryListModel result = await Mediator.Send(getListSubCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdSubCategoryQuery getByIdSubCategoryQuery)
    {
        GetByIdSubCategoryDto result = await Mediator.Send(getByIdSubCategoryQuery);
        return Ok(result);
    }
}