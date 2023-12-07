namespace CRM.Trust.Application.Services.Scorings.Dtos;

public class UpdateScoringParameterDto
{
    /// <summary>
    /// Идентификтаор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование параметра
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// ИД скоринговой модели
    /// </summary>
    public Guid ScoringId { get; set; }
    /// <summary>
    /// Интервалы
    /// </summary>
    public List<UpdateScoringParameterIntervalDto>? Intervals { get; set; }
}