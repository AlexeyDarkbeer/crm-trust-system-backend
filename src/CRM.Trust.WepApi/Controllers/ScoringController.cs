using Microsoft.AspNetCore.Mvc;

namespace CRM.Trust.WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoringController : ControllerBase
    {
        private readonly ILogger<ScoringController> _logger;

        public ScoringController(ILogger<ScoringController> logger)
        {
            _logger = logger;
        }
    }
}
