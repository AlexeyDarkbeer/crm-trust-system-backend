namespace CRM.Trust.Domain.Core;

/// <summary>
/// Контактная информация физического лица
/// </summary>
public class PersonContact
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; set; }
    /// <summary>
    /// ИД Физического лица
    /// </summary>
    public Guid PersonId { get; set; }
    
    public virtual Person Person { get; set; }
}