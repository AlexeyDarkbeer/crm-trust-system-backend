namespace CRM.Trust.Application.Services.Persons.Models;

public class PersonJobModel
{
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
}