using CRM.Trust.Application.Services.Scorings;
using CRM.Trust.Application.Services.Scorings.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Trust.WepApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ScoringController : ControllerBase
    {
        private readonly ILogger<ScoringController> _logger;
        private readonly IScoringService _scoringService;

        public ScoringController(ILogger<ScoringController> logger, IScoringService scoringService)
        {
            _logger = logger;
            _scoringService = scoringService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateScoringModel(CreateScoringDto createScoringDto, CancellationToken cancellationToken)
        {
            var result = await _scoringService.CreateScoringModelAsync(createScoringDto, cancellationToken);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }
    }
}
