using FluentResults;

namespace CRM.Trust.Application.Common.Errors;

public class NotFoundEntityError : Error
{
    public NotFoundEntityError(string entityName, int entityId)
    {
        this.Message = $"Entity '{entityName}' with id #{entityId} was not found!";
    }
    
    public NotFoundEntityError(string entityName, Guid entityId)
    {
        this.Message = $"Entity '{entityName}' with id #{entityId} was not found!";
    }
    
    public NotFoundEntityError(string entityName, string entityId)
    {
        this.Message = $"Entity '{entityName}' with id #{entityId} was not found!";
    }
}