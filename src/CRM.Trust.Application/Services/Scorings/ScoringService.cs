using AutoMapper;
using CRM.Trust.Application.Common.Errors;
using CRM.Trust.Application.Data;
using CRM.Trust.Application.Services.Scorings.Dtos;
using CRM.Trust.Domain.Scoring;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace CRM.Trust.Application.Services.Scorings;

public interface IScoringService
{
    Task<Result<Guid>> CreateScoringModelAsync(CreateScoringDto createScoringDto, CancellationToken cancellationToken);
    Task<Result<Guid>> UpdateScoringModelAsync(UpdateScoringDto updateScoringDto, CancellationToken cancellationToken);
    Task<Result<int>> AddScoringParameterAsync(AddScoringParameterDto addScoringParameterDto, CancellationToken cancellationToken);
    Task<Result<int>> UpdateScoringParameterAsync(UpdateScoringParameterDto updateScoringParameterDto, CancellationToken cancellationToken);
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

    public async Task<Result<Guid>> CreateScoringModelAsync(CreateScoringDto createScoringDto, CancellationToken cancellationToken)
    {
        var scoring = _mapper.Map<Scoring>(createScoringDto);
        await _scoringContext.Scorings.AddAsync(scoring, cancellationToken);
        await _scoringContext.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(scoring.Id);
    }
    
    public async Task<Result<Guid>> UpdateScoringModelAsync(UpdateScoringDto updateScoringDto, CancellationToken cancellationToken)
    {
        var scoring = await _scoringContext.Scorings
            .FirstOrDefaultAsync(e => e.Id == updateScoringDto.Id, cancellationToken);
        if (scoring is null)
        {
            return Result.Fail(new NotFoundEntityError(nameof(Scoring), updateScoringDto.Id));
        }

        scoring.Name = updateScoringDto.Name;
        scoring.Description = updateScoringDto.Description;
        
        await _scoringContext.SaveChangesAsync(cancellationToken);
        return Result.Ok(scoring.Id);
    }
    
    public async Task<Result<int>> AddScoringParameterAsync(AddScoringParameterDto addScoringParameterDto, CancellationToken cancellationToken)
    {
        var scoring = await _scoringContext.Scorings
            .FirstOrDefaultAsync(e => e.Id == addScoringParameterDto.ScoringId, cancellationToken);
        if (scoring is null)
        {
            return Result.Fail(new NotFoundEntityError(nameof(Scoring), addScoringParameterDto.ScoringId));
        }

        var parameter = _mapper.Map<ScoringParameter>(addScoringParameterDto);
        await _scoringContext.ScoringParameters.AddAsync(parameter, cancellationToken);
        await _scoringContext.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(parameter.Id);
    }
    
    public async Task<Result<int>> UpdateScoringParameterAsync(UpdateScoringParameterDto updateScoringParameterDto, CancellationToken cancellationToken)
    {
        var scoringParameter = await _scoringContext.ScoringParameters
            .Include(e => e.ScoringParameterIntervals)
            .FirstOrDefaultAsync(e => e.Id == updateScoringParameterDto.Id, cancellationToken);
        if (scoringParameter is null)
        {
            return Result.Fail(new NotFoundEntityError(nameof(ScoringParameter), updateScoringParameterDto.Id));
        }

        scoringParameter.ScoringId = updateScoringParameterDto.ScoringId; //TODO подумать над тем, нужно ли иметь функционал изменения модели параметра
        scoringParameter.Name = updateScoringParameterDto.Name;
        scoringParameter.Description = updateScoringParameterDto.Description;

        foreach (var parameterInterval in scoringParameter.ScoringParameterIntervals)
        {
            var intervalDto = updateScoringParameterDto.Intervals
                .FirstOrDefault(e => e.Id == parameterInterval.Id);
            parameterInterval.Weight = intervalDto.Weight;
            parameterInterval.MinValue = intervalDto.MinValue;
            parameterInterval.MaxValue = intervalDto.MaxValue;
        }
        await _scoringContext.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(scoringParameter.Id);
    }
}