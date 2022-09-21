using Application.Features.Category.Commands;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Dtos;
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