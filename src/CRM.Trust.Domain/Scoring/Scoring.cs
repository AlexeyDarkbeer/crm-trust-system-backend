namespace CRM.Trust.Domain.Scoring;

/// <summary>
/// Скоринговая модель
/// </summary>
public class Scoring
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование сокринговой модели
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание модели
    /// </summary>
    public string? Description { get; set; }
    
    public ICollection<ScoringParameter> ScoringParameters { get; set; }
}