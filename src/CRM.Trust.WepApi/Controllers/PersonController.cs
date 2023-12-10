using CRM.Trust.Application.Services.Persons;
using CRM.Trust.Application.Services.Persons.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Trust.WepApi.Controllers;

public class PersonController : ApiController
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetPersonList(CancellationToken cancellationToken)
    {
        var personListResult = await _personService.GetPersonsList(cancellationToken);
        if (personListResult.IsSuccess)
        {
            return Ok(personListResult.Value);
        }
        return BadRequest(personListResult.Errors.FirstOrDefault());
    }
    
    [HttpPost("LoadMany")]
    public async Task<IActionResult> LoadPersonsList(List<PersonLoadModel> personList, CancellationToken cancellationToken)
    {
        var result = await _personService.LoadPersonsList(personList, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(result.Errors.FirstOrDefault());
    }
}