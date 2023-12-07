using CRM.Trust.Application.HttpClients;
using Microsoft.Extensions.Logging;

namespace CRM.Trust.Application.Services.MathCore;

public interface IMathCoreService
{
}

public class MathCoreService : IMathCoreService
{
    private readonly ILogger<MathCoreService> _logger;
    private readonly IMathCoreHttpClient _mathCoreHttpClient;

    public MathCoreService(ILogger<MathCoreService> logger, IMathCoreHttpClient mathCoreHttpClient)
    {
        _logger = logger;
        _mathCoreHttpClient = mathCoreHttpClient;
    }
}