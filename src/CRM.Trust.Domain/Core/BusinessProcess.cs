namespace CRM.Trust.Domain.Core;

/// <summary>
/// Бизнес-процесс, происходящий в отношении физического лица
/// </summary>
public class BusinessProcess
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid BusinessProcessStageId { get; set; }
    
    public virtual Person Person { get; set; }
    public virtual BusinessProcessStage Stage { get; set; }
}