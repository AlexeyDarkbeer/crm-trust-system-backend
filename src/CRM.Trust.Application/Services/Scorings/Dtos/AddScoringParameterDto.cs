namespace CRM.Trust.Application.Services.Scorings.Dtos;

public class AddScoringParameterDto
{
    /// <summary>
    /// ИД скоринговой модели
    /// </summary>
    public Guid ScoringId { get; set; }
    /// <summary>
    /// Наименование параметра
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Интервалы параметра
    /// </summary>
    public List<AddScoringParameterIntervalDto>? Intervals { get; set; }
}