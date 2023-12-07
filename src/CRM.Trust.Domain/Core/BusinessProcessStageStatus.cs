namespace CRM.Trust.Domain.Core;

/// <summary>
/// Статус бизнесс процесса (открыт, исполнен, активен, закрыт)
/// </summary>
public class BusinessProcessStageStatus
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}