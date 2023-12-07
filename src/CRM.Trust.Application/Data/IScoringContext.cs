using CRM.Trust.Domain.Scoring;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Application.Data;

public interface IScoringContext : IDataContext
{ 
    DbSet<Scoring> Scorings { get; set; }
    DbSet<ScoringParameter> ScoringParameters { get; set; }
    DbSet<ScoringParameterInterval> ScoringParameterIntervals { get; set; }
    DbSet<ScoringOutput> ScoringOutputs { get; set; }
}