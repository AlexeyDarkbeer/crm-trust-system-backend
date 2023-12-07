namespace CRM.Trust.Domain.Core;

/// <summary>
/// Адрес физического лица
/// </summary>
public class PersonAddress
{
    /// <summary>
    /// ИД адреса
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Тип адреса (работа, дом)
    /// </summary>
    public string? AddressType { get; set; }
    /// <summary>
    /// ИД физического лица
    /// </summary>
    public Guid PersonId { get; set; }

    public virtual Person Person { get; set; }
}