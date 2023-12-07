namespace CRM.Trust.Domain.Core;

public class LoanPayment
{
    /// <summary>
    /// ИД платежа
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Сумма к оплате
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Дата платежа по расписанию
    /// </summary>
    public DateTime Date { get; set; }
    /// <summary>
    /// Дата оплаты платежа
    /// </summary>
    public DateTime? PaymentDate { get; set; }
    /// <summary>
    /// ИД кредита
    /// </summary>
    public string LoanId { get; set; }
    
    public virtual Loan Loan { get; set; }
}