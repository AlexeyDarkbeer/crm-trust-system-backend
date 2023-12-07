namespace CRM.Trust.Domain.Core;

/// <summary>
/// Место работы физического лица
/// </summary>
public class PersonJob
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование компании
    /// </summary>
    public string CompanyName { get; set; }
    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; set; }
    /// <summary>
    /// Ежемесячный доход
    /// </summary>
    public decimal SalaryAmount { get; set; }
    /// <summary>
    /// Дата начала работы
    /// </summary>
    public DateTime StartDate { get; set; }
    /// <summary>
    /// Дата окончания работы
    /// </summary>
    public DateTime? EndDate { get; set; }
    /// <summary>
    /// ИД физического лица
    /// </summary>
    public Guid PersonId { get; set; }
    
    public virtual Person Person { get; set; }
}