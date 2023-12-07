using CRM.Trust.Application.Data;
using CRM.Trust.Domain.Scoring;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Infrastructure.Data;

public class ScoringContext : DbContext, IScoringContext
{
    public const string SCHEMA = "Scoring";

    public DbSet<Scoring> Scorings { get; set; }
    public DbSet<ScoringParameter> ScoringParameters { get; set; }
    public DbSet<ScoringParameterInterval> ScoringParameterIntervals { get; set; }
    public DbSet<ScoringOutput> ScoringOutputs { get; set; }

    public ScoringContext(DbContextOptions<ScoringContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(SCHEMA);
        
        modelBuilder.Entity<Scoring>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(150);
            entity
                .HasMany(e => e.ScoringParameters)
                .WithOne(e => e.Scoring)
                .HasForeignKey(e => e.ScoringId);
        });
        modelBuilder.Entity<ScoringParameter>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.Description).HasMaxLength(170);
            entity
                .HasMany(e => e.ScoringParameterIntervals)
                .WithOne(e => e.ScoringParameter)
                .HasForeignKey(e => e.ScoringParameterId);
        });
        modelBuilder.Entity<ScoringParameterInterval>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<ScoringOutput>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity
                .HasOne(e => e.Scoring)
                .WithMany()
                .HasForeignKey(e => e.ScoringId);
        });
    }
}