using CRM.Trust.Application.Data;
using CRM.Trust.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Infrastructure.Data;

public class CoreContext : DbContext, ICoreContext
{
    public const string SCHEMA = "Core";

    public DbSet<BusinessProcess> BusinessProcesses { get; set; }
    public DbSet<BusinessProcessStage> BusinessProcessesStages { get; set; }
    public DbSet<BusinessProcessStageStatus> BusinessProcessesStageStatuses { get; set; }
    public DbSet<BusinessProcessStageTransition> BusinessProcessesStageTransitions { get; set; }
    
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonAddress> PersonAddresses { get; set; }
    public DbSet<PersonContact> PersonContacts { get; set; }
    public DbSet<PersonJob> PersonJobs { get; set; }
    public DbSet<PersonPassport> PersonPassports { get; set; }
    
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanPayment> LoanPayments { get; set; }

    public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SCHEMA);

        modelBuilder.Entity<BusinessProcess>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .HasOne(e => e.Person)
                .WithMany()
                .HasForeignKey(e => e.PersonId);
            entity
                .HasOne(e => e.Stage)
                .WithMany()
                .HasForeignKey(e => e.BusinessProcessStageId);
        });

        modelBuilder.Entity<BusinessProcessStage>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(60);
            entity.Property(e => e.Description).HasMaxLength(150);

            entity
                .HasOne(e => e.Status)
                .WithMany()
                .HasForeignKey(e => e.BusinessProcessStageStatusId);
        });

        modelBuilder.Entity<BusinessProcessStageStatus>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<BusinessProcessStageTransition>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .HasOne(e => e.FromStage)
                .WithMany()
                .HasForeignKey(e => e.FromStageId);
            entity
                .HasOne(e => e.ToStage)
                .WithMany()
                .HasForeignKey(e => e.ToStageId);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId);
            entity.Property(e => e.CreditType).HasMaxLength(50);
        });

        modelBuilder.Entity<LoanPayment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity
                .HasOne(e => e.Loan)
                .WithMany()
                .HasForeignKey(e => e.LoanId);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.MiddleName).HasMaxLength(150);
            entity.Property(e => e.Gender).HasMaxLength(10);
        });

        modelBuilder.Entity<PersonAddress>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.AddressType).HasMaxLength(50);
            entity
                .HasOne(e => e.Person)
                .WithMany(p => p.Addresses)
                .HasForeignKey(e => e.PersonId);
        });

        modelBuilder.Entity<PersonContact>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity
                .HasOne(e => e.Person)
                .WithMany(p => p.Contacts)
                .HasForeignKey(e => e.PersonId);
        });

        modelBuilder.Entity<PersonJob>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.CompanyName).HasMaxLength(150);
            entity.Property(e => e.Position).HasMaxLength(100);
            entity
                .HasOne(e => e.Person)
                .WithMany(p => p.Jobs)
                .HasForeignKey(e => e.PersonId);
        });

        modelBuilder.Entity<PersonPassport>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Series).HasMaxLength(10);
            entity.Property(e => e.Number).HasMaxLength(25);
            entity.Property(e => e.IssuedBy).HasMaxLength(100);
            entity.Property(e => e.DepartmentNumber).HasMaxLength(10);
            entity
                .HasOne(e => e.Person)
                .WithMany(p => p.Passports)
                .HasForeignKey(e => e.PersonId);
        });
    }
}