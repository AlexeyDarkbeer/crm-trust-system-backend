namespace CRM.Trust.Application.Services.Persons.Models;

public class PersonPassportModel
{
    /// <summary>
    /// Серия
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
}