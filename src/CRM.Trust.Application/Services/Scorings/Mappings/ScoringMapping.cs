using AutoMapper;
using CRM.Trust.Application.Services.Scorings.Dtos;
using CRM.Trust.Application.Services.Scorings.Models;
using CRM.Trust.Domain.Scoring;

namespace CRM.Trust.Application.Services.Scorings.Mappings;

public class ScoringMapping : Profile
{
    public ScoringMapping()
    {
        CreateMap<CreateScoringDto, Scoring>()
            .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description));
    }
}