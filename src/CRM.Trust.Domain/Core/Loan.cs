namespace CRM.Trust.Domain.Core;

/// <summary>
/// Кредит
/// </summary>
public class Loan
{
    public string LoanId { get; set; }
    public string CreditType { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public virtual ICollection<LoanPayment> LoanPayments { get; set; }
}