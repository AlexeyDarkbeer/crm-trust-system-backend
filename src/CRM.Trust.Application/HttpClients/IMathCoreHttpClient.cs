namespace CRM.Trust.Application.HttpClients;

public interface IMathCoreHttpClient
{
    Task GetMathData(CancellationToken cancellationToken);
}