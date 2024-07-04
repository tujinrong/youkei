using System.Data;

namespace BatchService.Trigger.Base.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class BatchMethodAttribute : Attribute
{
    public readonly string Description;
    public readonly IsolationLevel IsolationLevel;

    public BatchMethodAttribute(string? description = null, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        Description = description ?? string.Empty;
        IsolationLevel = isolationLevel;
    }
}