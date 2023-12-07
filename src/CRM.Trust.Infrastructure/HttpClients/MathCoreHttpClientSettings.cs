using System.ComponentModel.DataAnnotations;

namespace CRM.Trust.Infrastructure.HttpClients;

public class MathCoreHttpClientSettings
{
    public const string SECTION = "ApiSettings:MathCore";
    public const string HTTP_CLIENT_NAME = "MathCore";
    
    [Required, Url]
    public string Url { get; set; }
}