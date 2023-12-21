using System.Text.Json.Serialization;

namespace CRM.Trust.Application.HttpClients;

public class PersonClustersResponse
{
    [JsonPropertyName("clusters")]
    public List<int> Clusters { get; set; }
}