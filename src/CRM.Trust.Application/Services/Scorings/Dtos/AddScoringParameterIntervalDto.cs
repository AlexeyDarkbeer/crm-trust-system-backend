namespace CRM.Trust.Application.Services.Scorings.Dtos;

public class AddScoringParameterIntervalDto
{
    /// <summary>
    /// Вес параметра
    /// </summary>
    public decimal Weight { get; set; }
    /// <summary>
    /// Промежуток От
    /// </summary>
    public int MinValue { get; set; }
    /// <summary>
    /// Промежуток До
    /// </summary>
    public int MaxValue { get; set; }
}