namespace Play.Common.Entities;

/// <summary>
/// Represents an entity with a unique identifier.
/// </summary>
public interface IEntity
{
    Guid Id { get; set; }
}
