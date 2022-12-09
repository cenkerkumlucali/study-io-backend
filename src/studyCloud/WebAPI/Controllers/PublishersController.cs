using Application.Features.Publishers.Commands.CreatePublisher;
using Application.Features.Publishers.Commands.DeletePublisher;
using Application.Features.Publishers.Commands.UpdatePublisher;
using Application.Features.Publishers.Models;
using Application.Features.Publishers.Queries.GetListPublisher;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PublishersController:BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add(
        [FromQuery] CreatePublisherCommandRequest createPublisherCommand)
    {
        CreatePublisherCommandResponse result = await Mediator.Send(createPublisherCommand);
        return Created("", result);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(
        [FromBody] UpdatePublisherCommandRequest updatePublisherCommand)
    {
        UpdatePublisherCommandResponse result = await Mediator.Send(updatePublisherCommand);
        return Created("", result);
    }
    
    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(
        [FromRoute] DeletePublisherCommandRequest deletePublisherCommand)
    {
        DeletePublisherCommandResponse result = await Mediator.Send(deletePublisherCommand);
        return Created("", result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList(
        [FromQuery] GetListPublisherQueryRequest getListPublisherQuery)
    {
        PublisherListModel result = await Mediator.Send(getListPublisherQuery);
        return Ok(result);
    }
    
  
}