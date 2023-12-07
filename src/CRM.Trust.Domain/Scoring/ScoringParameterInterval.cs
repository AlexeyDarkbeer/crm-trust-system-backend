namespace CRM.Trust.Domain.Scoring;

/// <summary>
/// Интервал от..до.. параметра скоринга с значением веса параметра на интервале
/// </summary>
public class ScoringParameterInterval
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
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
    /// <summary>
    /// ИД параметра скоринга
    /// </summary>
    public int ScoringParameterId { get; set; }
    
    public virtual ScoringParameter ScoringParameter { get; set; }
}