namespace BatchService.Trigger.Base.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class BatchServiceAttribute : Attribute
{
    public readonly string? Name;
    public readonly string Description;

    public BatchServiceAttribute(string? name = null, string? description = null)
    {
        Name = name;
        Description = description ?? string.Empty;
    }
}