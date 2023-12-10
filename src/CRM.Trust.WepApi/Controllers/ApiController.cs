using Microsoft.AspNetCore.Mvc;

namespace CRM.Trust.WepApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class ApiController : ControllerBase
{
}