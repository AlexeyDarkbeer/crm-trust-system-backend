namespace CRM.Trust.Application.Services.Persons.Models;

public class PersonLoanModel
{
    public string LoanId { get; set; }
    public string CreditType { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}