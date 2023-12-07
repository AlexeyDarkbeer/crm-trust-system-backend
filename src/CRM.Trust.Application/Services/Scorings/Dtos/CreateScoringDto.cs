namespace CRM.Trust.Application.Services.Scorings.Dtos;

public class CreateScoringDto
{
    /// <summary>
    /// Наименование сокринговой модели
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Описание модели
    /// </summary>
    public string? Description { get; set; }
}