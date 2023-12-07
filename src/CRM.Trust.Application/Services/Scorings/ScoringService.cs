using AutoMapper;
using CRM.Trust.Application.Data;
using CRM.Trust.Application.Services.Scorings.Dtos;
using CRM.Trust.Application.Services.Scorings.Models;
using CRM.Trust.Domain.Scoring;

namespace CRM.Trust.Application.Services.Scorings;

public interface IScoringService
{
    Task CreateScoringModelAsync(CreateScoringDto createScoringDto, CancellationToken cancellationToken);
    Task AddScoringParameterAsync(CancellationToken cancellationToken);
    Task UpdateScoringParameterAsync(CancellationToken cancellationToken);
    Task RemoveScoringParameterAsync(CancellationToken cancellationToken);
}

public class ScoringService : IScoringService
{
    private readonly IMapper _mapper;
    private readonly IScoringContext _scoringContext;

    public ScoringService(IMapper mapper, IScoringContext scoringContext)
    {
        _mapper = mapper;
        _scoringContext = scoringContext;
    }

    public async Task CreateScoringModelAsync(CreateScoringDto createScoringDto, CancellationToken cancellationToken)
    {
        var scoring = _mapper.Map<Scoring>(createScoringDto);
        await _scoringContext.Scorings.AddAsync(scoring, cancellationToken);
        await _scoringContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task AddScoringParameterAsync(CancellationToken cancellationToken)
    {
        
    }
    
    public async Task UpdateScoringParameterAsync(CancellationToken cancellationToken)
    {
        
    }
    
    public async Task RemoveScoringParameterAsync(CancellationToken cancellationToken)
    {
        
    }
}