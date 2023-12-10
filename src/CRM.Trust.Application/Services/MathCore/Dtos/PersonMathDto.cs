using CRM.Trust.Domain.Core;

namespace CRM.Trust.Application.Services.MathCore.Dtos;

public class PersonMathDto
{
    public Guid Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string Gender { get; set; }
    
    public List<Loan> Loans { get; set; }
}