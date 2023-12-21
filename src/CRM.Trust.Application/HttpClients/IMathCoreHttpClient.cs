using CRM.Trust.Application.Services.Persons.Models;

namespace CRM.Trust.Application.HttpClients;

public interface IMathCoreHttpClient
{
    Task<PersonClustersResponse?> GetMathData(List<PersonDetailsModel> data, CancellationToken cancellationToken);
}