using System.Net.Http.Json;
using System.Text.Json;
using CRM.Trust.Application.HttpClients;
using CRM.Trust.Application.Services.Persons.Models;

namespace CRM.Trust.Infrastructure.HttpClients;

//TODO если я останусь на этом дерьме, то нелогично сюда сервис внедрять (пробросить через метод данные)
public class MathCoreHttpClient : IMathCoreHttpClient
{
    private readonly HttpClient _httpClient;

    public MathCoreHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(MathCoreHttpClientSettings.HTTP_CLIENT_NAME);
    }

    public async Task<PersonClustersResponse?> GetMathData(List<PersonDetailsModel> data, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync(MathCoreHttpClientUri.ClustersData, data, cancellationToken);
        if (response.IsSuccessStatusCode == false)
        {
            return null;
        }

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        var clustersData = JsonSerializer.Deserialize<PersonClustersResponse>(responseBody);
        return clustersData;
    }
}