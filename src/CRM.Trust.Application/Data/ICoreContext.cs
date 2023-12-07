using CRM.Trust.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Application.Data;

public interface ICoreContext : IDataContext
{
    DbSet<BusinessProcess> BusinessProcesses { get; set; }
    DbSet<BusinessProcessStage> BusinessProcessesStages { get; set; }
    DbSet<BusinessProcessStageStatus> BusinessProcessesStageStatuses { get; set; }
    DbSet<BusinessProcessStageTransition> BusinessProcessesStageTransitions { get; set; }
    DbSet<Person> Persons { get; set; }
    DbSet<PersonAddress> PersonAddresses { get; set; }
    DbSet<PersonContact> PersonContacts { get; set; }
    DbSet<PersonJob> PersonJobs { get; set; }
    DbSet<PersonPassport> PersonPassports { get; set; }
    DbSet<Loan> Loans { get; set; }
    DbSet<LoanPayment> LoanPayments { get; set; }
}