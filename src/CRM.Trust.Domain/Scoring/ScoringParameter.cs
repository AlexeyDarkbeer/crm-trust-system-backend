namespace CRM.Trust.Domain.Scoring;

/// <summary>
/// Параметр скоринга
/// </summary>
public class ScoringParameter
{
    /// <summary>
    /// Идентификтаор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование параметра
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// ИД скоринговой модели
    /// </summary>
    public Guid ScoringId { get; set; }
    
    public virtual Scoring Scoring { get; set; }
    public virtual ICollection<ScoringParameterInterval> ScoringParameterIntervals { get; set; }
}