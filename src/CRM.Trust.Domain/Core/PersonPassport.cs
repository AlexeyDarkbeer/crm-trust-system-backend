namespace CRM.Trust.Domain.Core;

/// <summary>
/// Паспорт физического лица
/// </summary>
public class PersonPassport
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Серия паспорта
    /// </summary>
    public string Series { get; set; }
    /// <summary>
    /// Номер паспорта
    /// </summary>
    public string Number { get; set; }
    /// <summary>
    /// Кем выдан
    /// </summary>
    public string IssuedBy { get; set; }
    /// <summary>
    /// Дата выдачи
    /// </summary>
    public DateTime IssueDate { get; set; }
    /// <summary>
    /// Номер отделения
    /// </summary>
    public string DepartmentNumber { get; set; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// Актуальность паспортных данных
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// ИД физического лица
    /// </summary>
    public Guid PersonId { get; set; }
    
    public virtual Person Person { get; set; }
}