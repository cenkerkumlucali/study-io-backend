using Application.Abstractions.Services.ElasticSearch;
using Application.DTOs.ElasticSearch;
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

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string text)
    {
        var result = (await
            _elasticSearch.GetSearchByField<UserDto>(
                new SearchByFieldParameters
                {
                    IndexName = "users",
                    FieldName = "UserName",
                    Value = text
                })).Select(c=>c.Item);

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