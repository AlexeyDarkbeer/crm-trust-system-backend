namespace CRM.Trust.Domain.Scoring;

/// <summary>
/// Результат подсчета скорингового балла по конкретной скоринговой модели
/// </summary>
public class ScoringOutput
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Скоринговый балл
    /// </summary>
    public decimal ScoringValue { get; set; }
    /// <summary>
    /// Дата вычисления
    /// </summary>
    public DateTime CalculateDate { get; set; }
    /// <summary>
    /// ИД физического лица
    /// </summary>
    public Guid PersonId { get; set; }
    /// <summary>
    /// Ид скоринговой модели
    /// </summary>
    public Guid ScoringId { get; set; }
    
    public virtual Scoring Scoring { get; set; }
}