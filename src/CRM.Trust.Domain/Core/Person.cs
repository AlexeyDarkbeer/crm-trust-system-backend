namespace CRM.Trust.Domain.Core;

/// <summary>
/// Физическое лицо
/// </summary>
public class Person
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string Gender { get; set; }
    
    public virtual ICollection<PersonPassport> Passports { get; set; }
    public virtual ICollection<PersonJob> Jobs { get; set; }
    public virtual ICollection<PersonContact> Contacts { get; set; }
    public virtual ICollection<PersonAddress> Addresses { get; set; }
    public virtual ICollection<Loan> Loans { get; set; }
}