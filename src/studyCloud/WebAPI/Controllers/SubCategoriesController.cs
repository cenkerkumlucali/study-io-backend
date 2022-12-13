using Application.Features.SubCategories.Commands.CreateSubCategory;
using Application.Features.SubCategories.Commands.DeleteSubCategory;
using Application.Features.SubCategories.Commands.UpdateSubCategory;
using Application.Features.SubCategories.Models;
using Application.Features.SubCategories.Queries.GetByIdSubCategory;
using Application.Features.SubCategories.Queries.GetListByParentId;
using Application.Features.SubCategories.Queries.GetListSubCategory;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoriesController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateSubCategoryCommandRequest createSubCategoryCommand)
    {
        CreateSubCategoryCommandResponse result = await Mediator.Send(createSubCategoryCommand);
        return Created("", result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateSubCategoryCommandRequest updateSubCategoryCommand)
    {
        UpdateSubCategoryCommandResponse result = await Mediator.Send(updateSubCategoryCommand);
        return Created("", result);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeleteSubCategoryCommandRequest deleteSubCategoryCommand)
    {
        DeleteSubCategoryCommandResponse result = await Mediator.Send(deleteSubCategoryCommand);
        return Created("", result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListSubCategoryQueryRequest getListSubCategoryQuery)
    {
        SubCategoryListModel result = await Mediator.Send(getListSubCategoryQuery);
        return Ok(result);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById(
        [FromQuery] GetByIdSubCategoryQueryRequest getByIdSubCategoryQuery)
    {
        GetByIdSubCategoryQueryResponse result = await Mediator.Send(getByIdSubCategoryQuery);
        return Ok(result);
    }
    
    [HttpGet("[action]/{ParentId}")]
    public async Task<IActionResult> GetListByParentId(
        [FromRoute] GetListByParentIdQueryRequest getListByParentIdQueryRequest)
    {
        List<GetListByParentIdQueryResponse> result = await Mediator.Send(getListByParentIdQueryRequest);
        return Ok(result);
    }
}