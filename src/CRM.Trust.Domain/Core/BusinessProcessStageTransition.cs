namespace CRM.Trust.Domain.Core;

/// <summary>
/// Карта перехода ступеней бизнес-процессов
/// </summary>
public class BusinessProcessStageTransition
{
    public int Id { get; set; }
    public Guid FromStageId { get; set; }
    public Guid? ToStageId { get; set; }
    
    public virtual BusinessProcessStage FromStage { get; set; }
    public virtual BusinessProcessStage? ToStage { get; set; }
}