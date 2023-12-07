namespace CRM.Trust.Application.Data;

public interface IDataContext : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}