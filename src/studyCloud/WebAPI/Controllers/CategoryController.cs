using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromBody] CreateCategoryCommand createCategoryCommand)
    {
        CreatedCategoryDto result = await Mediator.Send(createCategoryCommand);
        return Created("", result);
    } 
}