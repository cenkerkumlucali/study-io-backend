using Application.Abstractions.Services.ElasticSearch;
using Application.DTOs.ElasticSearch;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Search.Queries;
using Application.Features.Users.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchesController : BaseController
{
    private readonly IElasticSearch _elasticSearch;

    public SearchesController(IElasticSearch elasticSearch)
    {
        _elasticSearch = elasticSearch;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> Profile([FromQuery] GetUserQueryRequest getUserQueryRequest)
    {
        IList<GetUserQueryResponse> response = await Mediator.Send(getUserQueryRequest);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetUserQueryRequest getUserQueryRequest)
    {
        List<ElasticSearchGetModel<UserDto>> result = await
            _elasticSearch.GetSearchByField<UserDto>(
                new SearchByFieldParameters
                {
                    IndexName = "users",
                    FieldName = "UserName",
                    Value = getUserQueryRequest.Text
                });

        return Ok(result);
    }
}
// {
// "email": "elastic@elastic.com",
// "phoneNumber": "05514489217",
// "password": "cenker123",
// "firstName": "Elastic",
// "lastName": "Elastic"
// }