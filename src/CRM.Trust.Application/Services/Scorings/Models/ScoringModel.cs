namespace CRM.Trust.Application.Services.Scorings.Models;

public class ScoringModel
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