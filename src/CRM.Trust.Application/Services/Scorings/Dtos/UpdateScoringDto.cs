namespace CRM.Trust.Application.Services.Scorings.Dtos;

public class UpdateScoringDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование сокринговой модели
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание модели
    /// </summary>
    public string? Description { get; set; }
}