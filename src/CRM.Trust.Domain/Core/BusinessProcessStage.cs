namespace CRM.Trust.Domain.Core;

/// <summary>
/// Этап бизнесс-процесса
/// </summary>
public class BusinessProcessStage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid BusinessProcessStageStatusId { get; set; }
    
    public virtual BusinessProcessStageStatus Status { get; set; }
}