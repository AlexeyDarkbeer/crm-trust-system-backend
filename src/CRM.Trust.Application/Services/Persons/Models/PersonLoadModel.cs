namespace CRM.Trust.Application.Services.Persons.Models;

public class PersonLoadModel
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string? MiddleName { get; set; }
    /// <summary>
    /// Пол
    /// </summary>
    public string Gender { get; set; }
    /// <summary>
    /// Текущее место работы
    /// </summary>
    public PersonJobModel? ActualJob { get; set; }
    /// <summary>
    /// Паспорт
    /// </summary>
    public PersonPassportModel? Passport { get; set; }
    /// <summary>
    /// Контакты
    /// </summary>
    public List<PersonContactModel>? Contacts { get; set; }
}